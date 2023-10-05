using MediatR;
using static WeConnectBackend.Models.UserModels.Profiles;
using WeConnectBackend.Command.UserProfileCommand;
using WeConnectBackend.Data;
using WeConnectBackend.Services.UserServices;

namespace WeConnectBackend.Handler.UserProfilehandler
{
    public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand, UserProfile>
    {
        private readonly IUserProfileService _userProfileService;
        private readonly ApplicationDbContext _dbContext;

        public DeleteUserProfileCommandHandler(IUserProfileService userProfileService, ApplicationDbContext dbContext)
        {
            _userProfileService = userProfileService;
            _dbContext = dbContext;
        }

        public async Task<UserProfile> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
        {
            // finf user profile with the request.ApplicationUserId 
            var profile = _dbContext.UserProfiles.Where(u => u.UserId == request.Id).FirstOrDefault();
            UserProfile deletedUserProfile = await _userProfileService.DeleteUserProfile(profile);
            return deletedUserProfile;
        }
    }
}
