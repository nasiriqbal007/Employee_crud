using EmployeePortal.Data;
using EmployeePortal.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Repository
{
    public class EmployeeRepository
    {
        private readonly AppDbContext db;
        public EmployeeRepository(AppDbContext dbContext)
        {
            this.db = dbContext;
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await db.employees.ToListAsync();
        }
        public async Task AddEmployee(Employee emp)
        {
            await db.employees.AddAsync(emp);
            await db.SaveChangesAsync();
        }
        public async Task UpdateEmployee(int id, Employee emp)
        {
            var employee = await db.employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee not found");

            }
            employee.Name = emp.Name;
            employee.Email = emp.Email;
            employee.Age = emp.Age;
            employee.Salary = emp.Salary;
            employee.Status = emp.Status;
            await db.SaveChangesAsync();

        }
        public async Task deleteEmployee(int id)
        {
            var emp = await db.employees.FindAsync(id);
            if (emp == null)
            {
                throw new Exception("Employee not found");

            }

            db.employees.Remove(emp);
            await db.SaveChangesAsync();
        }
    }
}
