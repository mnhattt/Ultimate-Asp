using Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers;

[ApiController]
[Route("api/companies/{companyId}/employees")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> AddEmployeesToCompany(Guid companyId,
        [FromBody] IEnumerable<EmployeeForCreateDto> employeeForCreateDtos)
    {
        var emp = await _employeeService.AddEmployeesToCompany(companyId, employeeForCreateDtos);
        return CreatedAtAction(nameof(AddEmployeesToCompany), new { id = companyId }, employeeForCreateDtos);
    }
    
    [HttpPut("{Id}")]
    public async Task<ActionResult> UpdateEmployee(Guid Id, [FromBody] EmployeeForUpdateDto employeeForUpdateDtos)
    {
        await _employeeService.UpdateEmployee(Id, employeeForUpdateDtos);
        return NoContent();
    }
}