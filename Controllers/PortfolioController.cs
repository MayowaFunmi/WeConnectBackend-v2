using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WeConnectBackend.DTOs;
using WeConnectBackend.Services.Portfolio;
using static WeConnectBackend.Models.PortfolioModel.Projects;

namespace WeConnectBackend.Controllers;

[Route("api/[controller]")]
[ApiController]

public class PortfolioController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly IMapper _mapper;

    public PortfolioController(IProjectService projectService, IMapper mapper)
    {
        _projectService = projectService;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("add-new-project")]
    public async Task<GenericResponses> AddProject([FromBody] PortfolioDto portfolioDto)
    {
        // char separator = ',';
        // string[] stringArray = portfolioDto.Technologies.Split(separator, StringSplitOptions.RemoveEmptyEntries)
        //     .Select(item => item.Trim()).ToArray();
        // List<string> techList = new(stringArray);
        var mapPortfolio = _mapper.Map<Portfolio>(portfolioDto);
        var result = await _projectService.CreatePortfolio(mapPortfolio);
        if (result != null)
        {
            return new GenericResponses()
            {
                Status = HttpStatusCode.OK.ToString(),
                Message = "Project Added Successfully",
                Data = mapPortfolio
            };
        }
        else
        {
            return new GenericResponses()
            {
                Status = HttpStatusCode.BadGateway.ToString(),
                Message = "Failed to add Project",
                Data = null
            };
        }
    }

    [HttpDelete]
    [Route("delete-a-project")]
    public async Task<GenericResponses> DeleteProject([FromBody] string Id)
    {
        var result = await _projectService.DeletePortfolio(Id);
        if (result)
        {
            return new GenericResponses()
            {
                Status = HttpStatusCode.OK.ToString(),
                Message = $"Project with Id '{Id}' Deleted Successfully",
                Data = result
            };
        }
        return new GenericResponses()
        {
            Status = HttpStatusCode.BadRequest.ToString(),
            Message = "Failed to delete project",
            Data = null
        };
    }

    [HttpGet]
    [Route("list-all-projects")]
    public async Task<GenericResponses> GetAllProjects()
    {
        var result = await _projectService.GetPortfolioList();
        if (result.Count > 0)
        {
            return new GenericResponses()
            {
                Status = HttpStatusCode.OK.ToString(),
                Message = "All Projects Retrieved Successfully",
                Data = result
            };
        }
        else
        {
            return new GenericResponses()
            {
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "No Project Has Been Added!!!",
                Data = null
            };
        }
    }
}