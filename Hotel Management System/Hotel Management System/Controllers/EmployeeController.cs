using Hotel_Management_System.Data_Access_Layer;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace Hotel_Management_System.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext context;

        public EmployeeController(EmployeeDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetEmployeeDetails()
        {
            return Ok(context.employees.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeDetail([FromRoute] Guid id)
        {
            var roomid = context.employees.Find(id);

            if (roomid == null)
            {
                return NotFound();
            }
            return Ok(roomid);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployee addEmployee)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployee.Name,
                Age = addEmployee.Age,
                Address = addEmployee.Address,
                email = addEmployee.email,
                Number = addEmployee.Number,
                Salary = addEmployee.Salary,
                Employee_Designation = addEmployee.Employee_Designation
            };

            context.employees.Add(employee);
            context.SaveChanges();

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee([FromRoute] Guid id, UpdateEmployee updateEmp)
        {
            var empid = context.employees.Find(id);

            if (empid != null)
            {
                empid.Name = updateEmp.Name ;
                empid.email = updateEmp.email;
                empid.Age=updateEmp.Age;
                empid.Address=updateEmp.Address;
                empid.Salary=updateEmp.Salary;
                empid.Employee_Designation=updateEmp.Employee_Designation;

                context.SaveChanges();

                return Ok(empid);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee([FromRoute] Guid id)
        {
            var roomid = context.employees.Find(id);

            if (roomid != null)
            {
                context.employees.Remove(roomid);
                context.SaveChanges();

                return Ok(roomid);
            }

            return NotFound();
        }
    }
}
