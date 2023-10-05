using AutoMapper;
using WeConnectBackend.DTOs;
using static WeConnectBackend.Models.PortfolioModel.Projects;

namespace WeConnectBackend.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<PortfolioDto, Portfolio>();
    }
}