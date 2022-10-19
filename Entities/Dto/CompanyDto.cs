namespace Entities.Dto;

public record CompanyDto(Guid Id, string Name, string FullAddress);

public record CompanyForCreateDto(Guid Id, string Name, string Address, string Country,
    IEnumerable<EmployeeForCreateDto>? Employees);