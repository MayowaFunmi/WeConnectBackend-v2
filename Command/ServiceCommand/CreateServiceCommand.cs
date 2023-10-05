using MediatR;
using static WeConnectBackend.Models.ServiceCategory;
using static WeConnectBackend.Models.ServiceModel;
using static WeConnectBackend.Models.ServiceReview;
using static WeConnectBackend.Models.UserModels.AppUsers;

namespace WeConnectBackend.Command.ServiceCommand;

public class CreateServiceCommand : IRequest<Service>
{
    public CreateServiceCommand(ApplicationUser applicationUser, Service service, Category category)
    {
        ApplicationUser = applicationUser;
        Service = service;
        Category = category;
    }

    public Service Service { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public Category Category { get; set; }
}