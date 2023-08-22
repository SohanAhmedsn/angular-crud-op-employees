using System.ComponentModel.DataAnnotations;

namespace FullStackWebAPI.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
       
        public string Email { get; set; } = default!;
      
        public int Phone { get; set; } = default!;
      
        public decimal Salary { get; set; }
        public string Department { get; set; } = default!;
    }
}
