using MediatR;
using VideoStreamingUserServiceApplication.Applications.Common.Interfaces;
using VideoStreamingUserServiceApplication.Domain.Entities;
using VideoStreamingUserServiceApplication.Domain.ViewModels;

namespace VideoStreamingUserServiceApplication.Applications.Features.ProfileManagement
{
    public class AddUserProfileCommand:IRequest<BaseResponse<string>>
    {
        public long UserId {  get; set; }
        public string DisplayName {  get; set; }
        public string Bio {  get; set; }
        public string ProfileImageUrl {  get; set; }

    }

    public class AddUserProfileCommandHandler : IRequestHandler<AddUserProfileCommand, BaseResponse<string>>
    {
        private readonly ILogger<AddUserProfileCommandHandler> _logger;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        public AddUserProfileCommandHandler(ILogger<AddUserProfileCommandHandler> logger,IUnitOfWorkRepository unitOfWorkRepository)
        {
            _logger = logger;
            _unitOfWorkRepository = unitOfWorkRepository;
        }
        public Task<BaseResponse<string>> Handle(AddUserProfileCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("");
            var userProfile = new UserProfile
            { 
                UserId = request.UserId,
                DisplayName = request.DisplayName,
                Bio = request.Bio,
                ProfileImageUrl = request.ProfileImageUrl,             
            };
        }
    }
}
