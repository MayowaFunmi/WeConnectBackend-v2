namespace WeConnectBackend.Services.Portfolio;
using static WeConnectBackend.Models.PortfolioModel.Projects;

public interface IProjectService
{
    Task<Portfolio> CreatePortfolio(Portfolio portfolio);
    Task<Portfolio> UpdatePortfolio(Portfolio portfolio);
    Task<bool> DeletePortfolio(string Id);
    Task<List<Portfolio>> GetPortfolioList();
    Task<Portfolio> GetPortfolioById(string Id);
}