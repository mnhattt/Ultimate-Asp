using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Employee
{
    [Column("EmployeeId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage ="not null")]
    [MaxLength(50, ErrorMessage = "max length")]
    public string? Name { get; set; }

    public int Age { get; set; }

    public string? Position { get; set; }

    [ForeignKey(nameof(Company))]
    public Guid CompanyId { get; set; }
    
    public Company? Company { get; set; }
}