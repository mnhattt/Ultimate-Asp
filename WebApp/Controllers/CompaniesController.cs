using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly CompanyService _companyService;
    
    public CompaniesController(CompanyService companyService)
    {
        _companyService = companyService;
    }

    // GET: api/Company
    [HttpGet]
    public async Task<IEnumerable<CompanyDto>> GetAllCompanies()
    {
        return await _companyService.GetAllCompanies();
    }

    // GET: api/Company/5
    [HttpGet("{id}", Name = "Get")]
    public string Get(int id)
    {
        return "value";
    }

    // POST: api/Company
    [HttpPost]
    public void Post([FromBody] string value) { }

    // PUT: api/Company/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value) { }

    // DELETE: api/Company/5
    [HttpDelete("{id}")]
    public void Delete(int id) { }
}