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
    
    [HttpGet("{id}/test")]
    public void Test(Guid id)
    {
        _companyService.Test(id);
    }
    
    [HttpGet("{id:guid}", Name = "CompanyById")]
    public async  Task<IActionResult> GetCompany(Guid id)
    {
        var company = await _companyService.GetCompany(id);
        return Ok(company);
    }

    // POST: api/Company
    [HttpPost]
    public async Task<ActionResult<CompanyDto>> CreateCompany([FromBody] CompanyForCreateDto companyForCreateDto)
    {
        var company = await _companyService.CreateCompany(companyForCreateDto);
        return CreatedAtRoute("CompanyById", new { id = company.Id }, company);
    }

    // PUT: api/Company/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value) { }

    // DELETE: api/Company/5
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _companyService.DeleteCompany(Id);

        return NoContent();
    }
}