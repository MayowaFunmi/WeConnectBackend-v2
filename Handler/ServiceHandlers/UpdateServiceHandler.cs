using MediatR;
using WeConnectBackend.Command.ServiceCommand;
using WeConnectBackend.Data;
using WeConnectBackend.Services.Services;
using static WeConnectBackend.Models.ServiceModel;

namespace WeConnectBackend.Handler.ServiceHandlers;

public class UpdateServiceHandler : IRequestHandler<UpdateServiceCommand, Service>
{
    private readonly IService _service;
    private readonly ApplicationDbContext _dbContext;

    public UpdateServiceHandler(IService service, ApplicationDbContext dbContext)
    {
        _service = service;
        _dbContext = dbContext;
    }

    public async Task<Service> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var getService = _dbContext.Services.Where(s => s.ServiceId == request.Service.ServiceId).FirstOrDefault();
        if (getService != null)
        {
            getService.UserId = request.ApplicationUser.Id;
            getService.Title = request.Service.Title;
            getService.Description = request.Service.Description;
            getService.ServicePicture = request.Service.ServicePicture;
            getService.DurationQuantity = request.Service.DurationQuantity;
            getService.DurationUnit = request.Service.DurationUnit;
            getService.Price = request.Service.Price;
            getService.DeliveryTime = request.Service.DeliveryTime;
            getService.UpdatedAt = DateTime.Now;
            Service updatedService = await _service.UpdateService(getService);
            return updatedService;
        }
        return null;
    }
}