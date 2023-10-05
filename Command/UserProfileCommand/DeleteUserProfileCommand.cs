using MediatR;
using static WeConnectBackend.Models.UserModels.Profiles;

namespace WeConnectBackend.Command.UserProfileCommand
{
    public class DeleteUserProfileCommand : IRequest<UserProfile>
    {
        public string Id { get; set; }
    }
}
