using MediatR;
using static WeConnectBackend.Models.UserModels.Profiles;

namespace WeConnectBackend.Query.UserProfileQueries
{
    public class GetUserProfileListQuery : IRequest<List<UserProfile>>
    {

    }
}
