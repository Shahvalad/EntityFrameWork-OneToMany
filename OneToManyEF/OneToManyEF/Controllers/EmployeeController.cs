using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToManyEF.Data;

namespace OneToManyEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) { return BadRequest("Employee not found!"); }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employee)
        {
            if(employee==null)
            {
                return BadRequest("Enter valid data");
            }
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            var updatedEmployee = await _context.Employees.FindAsync(id);
            if (updatedEmployee == null) { return BadRequest("Employee not found!"); }

            updatedEmployee.FirstName = employee.FirstName;
            updatedEmployee.SecondName = employee.SecondName;
            updatedEmployee.Salary = employee.Salary;
            updatedEmployee.Age = employee.Age;

            await _context.SaveChangesAsync();
            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var deletedEmployee = await _context.Employees.FindAsync(id);
            if (deletedEmployee == null) { return BadRequest("Employee not found!"); }
            _context.Employees.Remove(deletedEmployee);
            await _context.SaveChangesAsync();
            return Ok(deletedEmployee);
        }

      
    }
}

