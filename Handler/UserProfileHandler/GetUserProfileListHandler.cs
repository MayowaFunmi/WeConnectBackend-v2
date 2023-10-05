using MediatR;
using static WeConnectBackend.Models.UserModels.Profiles;
using WeConnectBackend.Query.UserProfileQueries;
using WeConnectBackend.Services.UserServices;

namespace WeConnectBackend.Handler.UserProfilehandler
{
    public class GetUserProfileListHandler : IRequestHandler<GetUserProfileListQuery, List<UserProfile>>
    {
        private readonly IUserProfileService _userProfileService;

        public GetUserProfileListHandler(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        public async Task<List<UserProfile>> Handle(GetUserProfileListQuery request, CancellationToken cancellationToken)
        {
            return await _userProfileService.GetUserProfilesList();
        }
    }
}
