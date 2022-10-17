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

    public async  Task<IEnumerable<CompanyDto>> GetAllCompanies()
    {
        var companies = await _context.Companies.OrderBy(c => c. Name).ToListAsync();
        return _mapper.Map<IEnumerable<CompanyDto>>(companies);
    }
}