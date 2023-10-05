using WeConnectBackend.Data;
using WeConnectBackend.Models.PortfolioModel;
using Microsoft.EntityFrameworkCore;

namespace WeConnectBackend.Services.Portfolio;

public class ProjectService : IProjectService
{
    private readonly ApplicationDbContext _dbContext;
    public ProjectService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Projects.Portfolio> CreatePortfolio(Projects.Portfolio portfolio)
    {
        var result = _dbContext.Portfolios.Add(portfolio);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> DeletePortfolio(string Id)
    {
        var portfolio = await _dbContext.Portfolios.Where(p => p.PortfolioId.ToString() == Id).FirstOrDefaultAsync();
        if (portfolio != null)
        {
            _dbContext.Portfolios.Remove(portfolio);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<Projects.Portfolio> GetPortfolioById(string Id)
    {
        var portfolioData = await _dbContext.Portfolios.Where(p => p.PortfolioId.ToString() == Id).FirstOrDefaultAsync();
        if (portfolioData != null)
        {
            return portfolioData;
        }
        else
        {
            return null;
        }
    }

    public async Task<List<Projects.Portfolio>> GetPortfolioList()
    {
        var profileData = await _dbContext.Portfolios.ToListAsync();
        return profileData;
    }

    public async Task<Projects.Portfolio> UpdatePortfolio(Projects.Portfolio portfolio)
    {
        var result = _dbContext.Portfolios.Update(portfolio);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }
}