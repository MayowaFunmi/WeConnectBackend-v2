using MediatR;

namespace WeConnectBackend.Command.ServiceCommand;

public class DeleteServiceCommand : IRequest<bool>
{
    public string Id { get; set; }
}