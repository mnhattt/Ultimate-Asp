using Entities.Models;
using Repository;
using System.Linq;
using AutoMapper;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Services;

public class CompanyService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CompanyService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Test(Guid id)
    {
        var companies = _context.Companies.Include(x => x.Employees).Where(x => x.Id == id).Single();
        // companies.Employees.Clear();
        _context.SaveChanges();
    }

    public async Task<IEnumerable<CompanyDto>> GetAllCompanies()
    {
        var companies = await _context.Companies.OrderBy(c => c.Name).ToListAsync();
        return _mapper.Map<IEnumerable<CompanyDto>>(companies);
    }

    public async Task<CompanyDto> CreateCompany(CompanyForCreateDto company)
    {
        var companyEntity = _mapper.Map<Company>(company);
        _context.Companies.Add(companyEntity);
        _context.SaveChangesAsync();

        return _mapper.Map<CompanyDto>(companyEntity);
    }

    public async Task<CompanyDto> GetCompany(Guid Id)
    {
        var companyEntity = await _context.Companies.FirstOrDefaultAsync(c => c.Id == Id);
        if (companyEntity is null)
        {
            throw new Exception("dfdfdff");
        }

        return _mapper.Map<CompanyDto>(companyEntity);
    }

    public async Task DeleteCompany(Guid Id)
    {
        var company = await _context.Companies.FindAsync(Id);
        if (company is null)
        {
            throw new Exception("dfdfdff");
        }

        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();
    }
}