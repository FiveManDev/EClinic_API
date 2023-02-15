using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Enum;
using Project.Common.Functionality;
using Project.Common.Response;
using Project.NotificationService.Commands;

namespace Project.NotificationService.Handlers
{
    public class VerifyEmailHandler : IRequestHandler<VerifyEmailCommand, ObjectResult>
    {
        public async Task<ObjectResult> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(500);
            var code = RandomText.RandomByNumberOfCharacters(6, RandomType.Number);
            return ApiResponse.OK<string>(code);
        }
    }
}
