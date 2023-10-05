using MediatR;
using static WeConnectBackend.Models.UserModels.AppUsers;
using static WeConnectBackend.Models.UserModels.Profiles;

namespace WeConnectBackend.Command.UserProfileCommand
{
    public class CreateUserProfileCommand : IRequest<UserProfile>
    {
        public CreateUserProfileCommand(UserProfile userProfile, ApplicationUser applicationUser)
        {
            UserProfile = userProfile;
            ApplicationUser = applicationUser;
        }

        public UserProfile UserProfile { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
