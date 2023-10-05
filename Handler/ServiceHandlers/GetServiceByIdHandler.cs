using MediatR;
using WeConnectBackend.Query.ServiceQuery;
using WeConnectBackend.Services.Services;
using static WeConnectBackend.Models.ServiceModel;

namespace WeConnectBackend.Handler.ServiceHandlers;

public class GetServiceByIdHandler : IRequestHandler<GetServiceByIdQuery, Service>
{
    private readonly IService _service;

    public GetServiceByIdHandler(IService service)
    {
        _service = service;
    }

    public async Task<Service> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetServiceById(request.Id);
    }
}