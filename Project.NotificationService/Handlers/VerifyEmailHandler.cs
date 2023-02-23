﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Enum;
using Project.Common.Functionality;
using Project.Common.Response;
using Project.Core.Logger;
using Project.NotificationService.Commands;
using Project.NotificationService.Service;

namespace Project.NotificationService.Handlers
{
    public class VerifyEmailHandler : IRequestHandler<VerifyEmailCommand, ObjectResult>
    {
        private readonly ILogger<VerifyEmailHandler> logger;
        private readonly IMailService mailService;

        public VerifyEmailHandler(ILogger<VerifyEmailHandler> logger, IMailService mailService)
        {
            this.logger = logger;
            this.mailService = mailService;
        }

        public async Task<ObjectResult> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var code = RandomText.RandomByNumberOfCharacters(6, RandomType.Number);
                mailService.VerifyEmail(request.email, code);
                await Task.Delay(0);
                return ApiResponse.OK<string>(code);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
