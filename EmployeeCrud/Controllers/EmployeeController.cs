using EmployeeCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]

        public IActionResult GetAllEmployees() 
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]

        public IActionResult GetEmployeeById(int id) 
        {
            var employee = _employeeService.GetEmployeeById(id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]

        public IActionResult AddEmployee([FromBody] Employee employee) 
        {
            _employeeService.AddEmployee(employee);
            return Ok("Employee added successfully!");
        }

        [HttpPut ("{id}")]

        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            var existingEmployee = _employeeService.GetEmployeeById(id);
            if(existingEmployee == null)
            {
                return NotFound();
            }

            employee.Id = id;
            _employeeService.UpdateEmployee(employee);
            return Ok("Employee Updated Successfully!");
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteEmployee(int id) 
        {
            var existingEmployee = _employeeService.GetEmployeeById(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            _employeeService.DeleteEmployee(id);
            return Ok("Employee Deleted Successfully");
        }
    }
}
