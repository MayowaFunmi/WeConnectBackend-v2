using static WeConnectBackend.Models.UserModels.Profiles;

namespace WeConnectBackend.Services.UserServices
{
    public interface IUserProfileService
    {
        Task<List<UserProfile>> GetUserProfilesList();
        Task<UserProfile> GetUserProfileById(string Id);
        Task<UserProfile> CreateUserProfile(UserProfile userProfile);
        Task<UserProfile> UpdateUserProfile(UserProfile userProfile);
        Task<UserProfile> DeleteUserProfile(UserProfile userProfile);
    }
}
