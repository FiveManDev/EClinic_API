﻿using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Constants;
using Project.Common.Enum;
using Project.Common.Response;
using Project.Core.AWS;
using Project.Core.Logger;
using Project.Core.RabbitMQ;
using Project.ProfileService.Commands;
using Project.ProfileService.Events;
using Project.ProfileService.Repository.DoctorProfileRepository;
using Project.ProfileService.Repository.ProfileRepository;

namespace Project.ProfileService.Handlers.DoctorProfileHandlers
{
    public class UpdateDoctorProfileHandler : IRequestHandler<UpdateDoctorProfileCommands, ObjectResult>
    {
        private readonly IProfileRepository profileRepository;
        private readonly IDoctorProfileRepository doctorProfileRepository;
        private readonly IAmazonS3Bucket s3Bucket;
        private readonly ILogger<UpdateDoctorProfileHandler> logger;
        private readonly IBus bus;

        public UpdateDoctorProfileHandler(IProfileRepository profileRepository, IDoctorProfileRepository doctorProfileRepository, IAmazonS3Bucket s3Bucket, ILogger<UpdateDoctorProfileHandler> logger, IBus bus)
        {
            this.profileRepository = profileRepository;
            this.doctorProfileRepository = doctorProfileRepository;
            this.s3Bucket = s3Bucket;
            this.logger = logger;
            this.bus = bus;
        }

        public async Task<ObjectResult> Handle(UpdateDoctorProfileCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var profile = await profileRepository.GetAsync(request.UpdateDoctorProfileDtos.ProfileID);
                if (profile == null)
                {
                    return ApiResponse.NotFound("Profile Not Found.");
                }
                var profileDtos = request.UpdateDoctorProfileDtos;
                profile.FirstName = profileDtos.FirstName;
                profile.LastName = profileDtos.LastName;
                profile.Email = profileDtos.Email;
                profile.DateOfBirth = profileDtos.DateOfBirth;
                profile.Gender = profileDtos.Gender;
                profile.Address = profileDtos.Address;
                profile.Phone = profileDtos.Phone;
                if (profileDtos.Avatar != null)
                {
                    profile.Avatar = await s3Bucket.UploadFileAsync(profileDtos.Avatar, FileType.Image);
                }
                var doctorProfile = await doctorProfileRepository.GetAsync(profile.ProfileID);
                if (doctorProfile == null)
                {
                    return ApiResponse.NotFound("Profile Not Found.");
                }
                doctorProfile.WorkStart = profileDtos.WorkStart;
                doctorProfile.Description = profileDtos.Description;
                doctorProfile.Title = profileDtos.Title;
                doctorProfile.SpecializationID = profileDtos.SpecializationID;
                var updateDoctorResult = await doctorProfileRepository.UpdateAsync(doctorProfile);
                if (!updateDoctorResult)
                {
                    throw new Exception("Update Doctor Profile Error");
                }
                var updateProfileResult = await profileRepository.UpdateAsync(profile);
                if (!updateProfileResult)
                {
                    throw new Exception("Update Profile Error");
                }
                await bus.SendMessageWithExchangeName<UpdateProfileEvents>(new UpdateProfileEvents
                {
                    UserID = profile.UserID,
                    Avatar = profile.Avatar,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName
                }, ExchangeConstants.ForumService);
                return ApiResponse.OK("Update Profile Success");
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
