using MediatR;
using System.Diagnostics.Eventing.Reader;
using VideoStreamingUserServiceApplication.Applications.Common.Interfaces;
using VideoStreamingUserServiceApplication.Domain.ViewModels;

namespace VideoStreamingUserServiceApplication.Applications.Features.Registration
{
    public class LoginUserCommand : IRequest<BaseResponse<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, BaseResponse<string>>
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        private readonly ILogger<LoginUserCommandHandler> logger;
        private readonly IPasswordService passwordService;
        private readonly IJwtService jwtService;
        public LoginUserCommandHandler(IJwtService jwtService, ILogger<LoginUserCommandHandler> logger, IPasswordService passwordService, IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.jwtService = jwtService;
            this.logger = logger;
            this.passwordService = passwordService;
            this.unitOfWorkRepository = unitOfWorkRepository;
        }
        public async Task<BaseResponse<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await unitOfWorkRepository.UserRepository.GetUserByEmail(request.Email);
            if (user == null)
            {
                return new BaseResponse<string>(false, $"User with email {request.Email} not found");
            }
            var hashedPassword = passwordService.HashPassword(request.Password);
            if (user.PasswordHash != hashedPassword)
            {
                return new BaseResponse<string>(false, "Invalid credentials");
            }
            var token = jwtService.GenerateToken(user);
            return new BaseResponse<string>(true, token);
        }
    }
}
