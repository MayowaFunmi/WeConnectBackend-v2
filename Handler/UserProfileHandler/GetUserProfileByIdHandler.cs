using MediatR;
using static WeConnectBackend.Models.UserModels.Profiles;
using WeConnectBackend.Query.UserProfileQueries;
using WeConnectBackend.Services.UserServices;

namespace WeConnectBackend.Handler.UserProfilehandler
{
    public class GetUserProfileByIdHanlder : IRequestHandler<GetUserProfileByIdQuery, UserProfile>
    {
        private readonly IUserProfileService _userProfileService;

        public GetUserProfileByIdHanlder(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        public async Task<UserProfile> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userProfileService.GetUserProfileById(request.Id);
        }
    }
}
