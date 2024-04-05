using EmployeeCrud.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeCrud.Models
{
        public class EmployeeService : IEmployeeService
        {
            private readonly List<Employee> _employees;

            public EmployeeService()
            {
                _employees = new List<Employee>();
            }

            public IEnumerable<Employee> GetAllEmployees()
            {
                return _employees;
            }

            public Employee GetEmployeeById(int id) 
            {
                return _employees.FirstOrDefault(e => e.Id == id);
            }

            public void AddEmployee(Employee employee)
            {
                employee.Id = _employees.Count + 1;
                _employees.Add(employee);
            }

            public void UpdateEmployee(Employee employee)
            {
                var existingEmployee = _employees.FirstOrDefault(e => e.Id == employee.Id);

                if (existingEmployee != null)
                {
                    existingEmployee.Name = employee.Name;
                }
            }

            public void DeleteEmployee(int id)
            {
                var employeeToRemove = _employees.FirstOrDefault(e => e.Id == id);
                if (employeeToRemove != null)
                {
                    _employees.Remove(employeeToRemove);
                }
            }
        }
}
