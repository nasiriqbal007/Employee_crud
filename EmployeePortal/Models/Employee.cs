using System.ComponentModel.DataAnnotations;

namespace EmployeePortal.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

        public bool Status { get; set; }

    }
}
