using AutoMapper;
using Grpc.Net.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BookingService.Data;
using Project.BookingService.Dtos.BookingPackageDTOs;
using Project.BookingService.Protos;
using Project.BookingService.Repository.BookingPackageRepository;
using Project.BookingServiceQueries.Queries;
using Project.Common.Response;
using Project.Core.Logger;

namespace Project.BookingService.Handlers.BookingPackageHandler;

public class GetBookingPackageByIDHandler : IRequestHandler<GetBookingPackageByIDQuery, ObjectResult>
{
    private readonly IBookingPackageRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<GetBookingPackageByIDHandler> logger;
    private readonly ProfileService.ProfileServiceClient client;

    public GetBookingPackageByIDHandler(IConfiguration configuration, IBookingPackageRepository repository, IMapper mapper, ILogger<GetBookingPackageByIDHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
        // set up gRPC
        var httpHandler = new HttpClientHandler();
        httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
        GrpcChannel channel = GrpcChannel.ForAddress(configuration.GetValue<string>("GrpcSettings:ProfileServiceUrl"), new GrpcChannelOptions { HttpHandler = httpHandler });
        client = new ProfileService.ProfileServiceClient(channel);
    }

    public async Task<ObjectResult> Handle(GetBookingPackageByIDQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var bookingPackage = await repository.GetAsync(request.bookingPackageID);
            if (bookingPackage == null)
            {
                return ApiResponse.NotFound("Booking Package Not Found.");
            }

            var profile = await client.GetProfileAsync(new GetProfileRequest { UserID = bookingPackage.UserID.ToString() });
            if (string.IsNullOrEmpty(profile.UserID))
            {
                throw new Exception("Get Profile Error");
            }

            //var specialization = await client2.GetSpecialization(new GetSpecializationRequest { SpecializationID = bookingPackage.UserID.ToString() });
            //if (string.IsNullOrEmpty(profile.UserID))
            //{
            //    throw new Exception("Get Profile Error");
            //}

            BookingPackageDTO bookingPackageDTO = mapper.Map<BookingPackageDTO>(bookingPackage);
            bookingPackageDTO.User = new User {
                UserID = Guid.Parse(profile.UserID),
                Avatar = profile.Avatar,
                FirstName = profile.FirstName,
                LastName = profile.LastName
            };

            return ApiResponse.OK<BookingPackageDTO>(bookingPackageDTO);
        }
        catch (Exception ex)
        {
            logger.WriteLogError(ex.Message);
            return ApiResponse.InternalServerError();
        }
    }
}
