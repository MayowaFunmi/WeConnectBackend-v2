using MediatR;
using static WeConnectBackend.Models.UserModels.Profiles;

namespace WeConnectBackend.Query.UserProfileQueries
{
    public class GetUserProfileByIdQuery : IRequest<UserProfile>
    {
        public string Id { get; set; }
    }
}
