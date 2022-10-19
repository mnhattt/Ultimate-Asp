using System.Text.Json;
using AutoMapper;
using Entities.Dto;
using Entities.Models;
using Repository;

namespace WebApp.Services;

public class EmployeeService
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;
    private readonly ILogger<EmployeeService> _logger;

    public EmployeeService(IMapper mapper, AppDbContext context, ILogger<EmployeeService> logger)
    {
        _mapper = mapper;
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<EmployeeDto>> AddEmployeesToCompany(Guid companyId,
        IEnumerable<EmployeeForCreateDto> employeeForCreateDtos)
    {
        var employees = _mapper.Map<IEnumerable<Employee>>(employeeForCreateDtos);
        foreach (var e in employees)
        {
            _context.Employees.Add(e);
        }

        await _context.SaveChangesAsync();

        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }


    public async Task<EmployeeDto> UpdateEmployee(Guid Id, EmployeeForUpdateDto employeeDto)
    {
        var employee = await _context.Employees.FindAsync(Id);

        if (employee is null)
        {
            throw new Exception("dfdfdf");
        }

        // employee.Name = employeeDto.Name;
        // employee.Age = employeeDto.Age;
        // employee.Position = employeeDto.Position;
        _mapper.Map(employeeDto, employee);

        await _context.SaveChangesAsync();

        return _mapper.Map<EmployeeDto>(employee);
    }
}