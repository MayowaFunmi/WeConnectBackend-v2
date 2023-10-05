using MediatR;
using static WeConnectBackend.Models.ServiceModel;

namespace WeConnectBackend.Query.ServiceQuery;

public class GetServiceListQuery : IRequest<List<Service>>
{

}