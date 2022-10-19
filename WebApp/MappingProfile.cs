using Entities.Dto;
using Entities.Models;
using AutoMapper;

namespace WebApp;


public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ForCtorParam("FullAddress", opt => opt.MapFrom(x => string.Join("-", x.Address, x.Country)));

        CreateMap<CompanyForCreateDto, Company>();

        CreateMap<EmployeeForCreateDto, Employee>();

        CreateMap<Employee, EmployeeDto>();

        CreateMap<EmployeeForUpdateDto, Employee>();
    }
}