using Microsoft.AspNetCore.Identity;
using static WeConnectBackend.Models.UserModels.AppUsers;
using WeConnectBackend.Data;
using static WeConnectBackend.Models.ServiceModel;
using Microsoft.EntityFrameworkCore;

namespace WeConnectBackend.Services.Services
{
    public class ModelService : IService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public ModelService(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public async Task<Service> CreateService(Service service)
        {
            {
                var response = _dbContext.Services.Add(service);
                await _dbContext.SaveChangesAsync();
                return response.Entity;
            }
        }

        public async Task<bool> DeleteService(Service service)
        {
            try
            {
                var result = _dbContext.Services.Remove(service);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Service> GetServiceById(Guid Id)
        {
            var gig = await _dbContext.Services.Where(g => g.ServiceId == Id)
                .Select(g => new Service
                { 
                    UserId = g.UserId,
                    User = g.User,
                    Category = g.Category,
                    Title = g.Title,
                    Description = g.Description,
                    ServicePicture = g.ServicePicture,
                    DurationQuantity = g.DurationQuantity,
                    DurationUnit = g.DurationUnit,
                    Price = g.Price,
                    DeliveryTime = g.DeliveryTime,
                    Status = g.Status,
                    CreatedAt = g.CreatedAt,
                    UpdatedAt = g.UpdatedAt,
                    Reviews = g.Reviews,
                })
                .FirstOrDefaultAsync();
            if (gig != null)
            {
                return gig;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Service>> GetServiceList()
         {
            var servicesWithCategories = await _dbContext.Services
                .Include(s => s.Category)
                .Include(r => r.Reviews)
                .ToListAsync();
            return servicesWithCategories;
        }

        public async Task<Service> UpdateService(Service service)
        {
            var response = _dbContext.Services.Update(service);
            await _dbContext.SaveChangesAsync();
            return response.Entity;
        }
    }
}
