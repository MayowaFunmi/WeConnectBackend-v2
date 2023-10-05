using MediatR;
using WeConnectBackend.Command.ServiceCommand;
using WeConnectBackend.Services.Services;
using static WeConnectBackend.Models.ServiceModel;

namespace WeConnectBackend.Handler.ServiceHandlers;

public class CreateServiceHandler : IRequestHandler<CreateServiceCommand, Service>
{
    private readonly IService _service;

    public CreateServiceHandler(IService service)
    {
        _service = service;
    }

    public async Task<Service> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        Service service = new()
        {
            UserId = request.ApplicationUser.Id,
            CategoryId = request.Service.CategoryId,
            Title = request.Service.Title,
            Description = request.Service.Description,
            ServicePicture = request.Service.ServicePicture,
            DurationQuantity = request.Service.DurationQuantity,
            DurationUnit = request.Service.DurationUnit,
            Price = request.Service.Price,
            DeliveryTime = request.Service.DeliveryTime,
            CreatedAt = DateTime.Now
        };
        Service createdService = await _service.CreateService(service);
        return createdService;
    }
}