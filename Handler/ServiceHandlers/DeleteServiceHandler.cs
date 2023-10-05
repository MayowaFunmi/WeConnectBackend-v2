using MediatR;
using WeConnectBackend.Command.ServiceCommand;
using WeConnectBackend.Data;
using WeConnectBackend.Services.Services;

namespace WeConnectBackend.Handler.ServiceHandlers;

public class DeleteServiceHandler : IRequestHandler<DeleteServiceCommand, bool>
{
    private readonly IService _service;
    private readonly ApplicationDbContext _context;

    public DeleteServiceHandler(IService service, ApplicationDbContext context)
    {
        _service = service;
        _context = context;
    }

    public async Task<bool> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var model = _context.Services.Where(m => m.ServiceId.ToString() == request.Id).FirstOrDefault();
        if (model != null)
        {
            await _service.DeleteService(model);
            return true;
        }
        else
        {
            return false;
        }
    }
}