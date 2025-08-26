using EmployeePortal.Models;
using EmployeePortal.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase

    {
        private readonly EmployeeRepository emp;
        public EmployeeController(EmployeeRepository employeeRepository)
        {
            this.emp = employeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult> EmployeeList()
        {
            var allEmployees = await emp.GetAllEmployees();
            return Ok(allEmployees);
        }
        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee addEmp)
        {
            await emp.AddEmployee(addEmp);
            return Ok(addEmp);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> updateEmployee(int id, [FromBody] Employee updateEmp)
        {
            await emp.UpdateEmployee(id, updateEmp);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteEmployee(int id)
        {
            await emp.deleteEmployee(id);
            return Ok();
        }
    }
}
