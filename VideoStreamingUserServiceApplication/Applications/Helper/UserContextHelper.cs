using System.Security.Claims;

namespace VideoStreamingUserServiceApplication.Applications.Helper
{
    public class UserContextHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public UserContextHelper(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            var user = _contextAccessor.HttpContext?.User;
            if (user == null || !user.Identity.IsAuthenticated) return "";
            var userId = user.Claims.FirstOrDefault(c=> c.Type == ClaimTypes.NameIdentifier).Value;
            return userId;
        }
    }
}
