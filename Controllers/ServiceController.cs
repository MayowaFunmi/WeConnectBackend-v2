using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeConnectBackend.Data;
using WeConnectBackend.DTOs;
using static WeConnectBackend.Models.ServiceModel;
using static WeConnectBackend.Models.UserModels.AppUsers;

namespace WeConnectBackend.Controllers;

public class ServiceController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ServiceController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMediator mediator, IMapper mapper)
    {
        _context = context;
        _userManager = userManager;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("create-gig")]

    public async Task<GenericResponses> CreateService(ServiceDto serviceDto)
    {
        var category = _context.Categories.FirstOrDefault(c => c.CategoryId == serviceDto.CategoryId);
        var user =  await _userManager.FindByIdAsync(serviceDto.UserId);
        var srvc = _mapper.Map<Service>(serviceDto);
        return new GenericResponses()
        {

        };
    }
}