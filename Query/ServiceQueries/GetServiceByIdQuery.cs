using MediatR;
using static WeConnectBackend.Models.ServiceModel;

namespace WeConnectBackend.Query.ServiceQuery;

public class GetServiceByIdQuery : IRequest<Service>
{
    public Guid Id { get; set; }
}