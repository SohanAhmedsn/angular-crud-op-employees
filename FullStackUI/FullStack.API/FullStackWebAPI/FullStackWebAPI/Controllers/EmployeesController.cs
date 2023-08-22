using FullStackWebAPI.Data;
using FullStackWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly FullStackDbContext _context;
        public EmployeesController(FullStackDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployess()
        {
            var employees= await _context.Employees.ToListAsync();
            return Ok(employees);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployees([FromBody] Employee employee)
        {
            employee.Id = Guid.NewGuid();   
            await  _context.Employees.AddAsync(employee);   
            await _context.SaveChangesAsync();
            return Ok(employee);

        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute]Guid id)
        {
            var employees = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if(employees== null)
            {
                return NotFound();  
            }
            return Ok(employees);    
        }
        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee updateEmployeeRequest)
        {
            var employee= await _context.Employees.FindAsync(id);
            if(employee==null)
            {
                return NotFound();
            }
            
            employee.Name = updateEmployeeRequest.Name;
            employee.Email = updateEmployeeRequest.Email;
            employee.Salary = updateEmployeeRequest.Salary;
            employee.Phone = updateEmployeeRequest.Phone;
            employee.Department = updateEmployeeRequest.Department;
            await _context.SaveChangesAsync();  
            return Ok(employee);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _context.Employees.FindAsync(id); 
            if (employee==null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);    
            await _context.SaveChangesAsync();  
            return Ok(employee);    
        }

    }
}
