using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Company
{
    [Column("CompanyId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "not null")]
    [MaxLength(50, ErrorMessage = "max length")]
    public string? Name { get; set; }


    [Required(ErrorMessage = "not null")]
    [MaxLength(50, ErrorMessage = "max length")]
    public string? Address { get; set; }

    public string? Country { get; set; }

    public ICollection<Employee>? Employees { get; set; }
}