using MediatR;
using static WeConnectBackend.Models.UserModels.Profiles;
using WeConnectBackend.Command.UserProfileCommand;
using WeConnectBackend.Services.UserServices;

namespace WeConnectBackend.Handler.UserProfilehandler
{
    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, UserProfile>
    {
        private readonly IUserProfileService _userProfileService;

        public CreateUserProfileCommandHandler(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        public async Task<UserProfile> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            UserProfile profile = new()
            {
                //Id = d20b7318-2001-42a4-8e44-8cdf3328ef7d
                UserId = request.ApplicationUser.Id,
                Gender = request.UserProfile.Gender,
                MaritalStatus = request.UserProfile.MaritalStatus,
                Occupation = request.UserProfile.Occupation,
                Address = request.UserProfile.Address,
                DateOfBirth = request.UserProfile.DateOfBirth,
                Nationality = request.UserProfile.Nationality,
                ProfilePicture = request.UserProfile.ProfilePicture,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            UserProfile createdUserProfile = await _userProfileService.CreateUserProfile(profile);
            return createdUserProfile;
        }
    }
}
