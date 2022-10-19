namespace Entities.Dto;

public record EmployeeDto(Guid Id, string Name, int Age, string Position);

public record EmployeeForUpdateDto(string Name, int Age, string Position);

public record EmployeeForCreateDto(string Name, int Age, string Position, Guid CompanyId);