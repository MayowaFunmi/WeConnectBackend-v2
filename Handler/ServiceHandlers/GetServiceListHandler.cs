using MediatR;
using WeConnectBackend.Query.ServiceQuery;
using WeConnectBackend.Services.Services;
using static WeConnectBackend.Models.ServiceModel;

namespace WeConnectBackend.Handler.ServiceHandlers;

public class GetServiceListHandler : IRequestHandler<GetServiceListQuery, List<Service>>
{
    private readonly IService _service;

    public GetServiceListHandler(IService service)
    {
        _service = service;
    }

    public async Task<List<Service>> Handle(GetServiceListQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetServiceList();
    }
}