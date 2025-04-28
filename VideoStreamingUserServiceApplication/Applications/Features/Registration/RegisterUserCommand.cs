using MediatR;
using VideoStreamingUserServiceApplication.Applications.Common.Interfaces;
using VideoStreamingUserServiceApplication.Domain.Entities;
using VideoStreamingUserServiceApplication.Domain.Enums;
using VideoStreamingUserServiceApplication.Domain.ViewModels;

namespace VideoStreamingUserServiceApplication.Applications.Features.Registration
{
    public class RegisterUserCommand:IRequest<BaseResponse<string>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Subscription Subscription { get; set; }
    }
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, BaseResponse<string>>
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        private readonly IPasswordService passwordService;
        private readonly IJwtService jwtService;
        public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordService passwordService, IJwtService jwtService)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
            this.passwordService = passwordService;
            this.jwtService = jwtService;
        }
        public async Task<BaseResponse<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var hashedPassword = passwordService.HashPassword(request.Password);
            var newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = hashedPassword,
                Role = UserRole.User,
                Subscription = Subscription.Free
            };

            var response = await unitOfWorkRepository.UserRepository.AddUserAsync(newUser);
           // var token = jwtService.GenerateToken(newUser);
            return new BaseResponse<string>(true, "User created successfully");
        }
    }
}
