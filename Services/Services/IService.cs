using Microsoft.EntityFrameworkCore.Metadata;
using static WeConnectBackend.Models.ServiceModel;

namespace WeConnectBackend.Services.Services
{
    public interface IService
    {
        Task<List<Service>> GetServiceList();
        Task<Service> GetServiceById(Guid Id);
        Task<Service> CreateService(Service service);
        Task<Service> UpdateService(Service service);
        Task<bool> DeleteService(Service service);

    }
}
