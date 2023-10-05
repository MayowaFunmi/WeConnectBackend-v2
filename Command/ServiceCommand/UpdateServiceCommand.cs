using MediatR;
using static WeConnectBackend.Models.ServiceCategory;
using static WeConnectBackend.Models.ServiceModel;
using static WeConnectBackend.Models.UserModels.AppUsers;

namespace WeConnectBackend.Command.ServiceCommand;

public class UpdateServiceCommand : IRequest<Service>
    {
        public UpdateServiceCommand(Service service, ApplicationUser applicationUser, Category category)
        {
            Service = service;
            ApplicationUser = applicationUser;
            Category = category;
        }

        public Service Service { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Category Category { get; set; }
    }