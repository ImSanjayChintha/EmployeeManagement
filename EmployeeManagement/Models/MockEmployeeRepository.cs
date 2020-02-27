using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { 
                    Id = 1, 
                    Name = "Mary", 
                    Department = Dept.IT, 
                    Email = "mary@pragimtech.com", 
                    PhotoPath="" 
                },
                new Employee() { 
                    Id = 2, 
                    Name = "John", 
                    Department = Dept.Finance, 
                    Email = "john@pragimtech.com", 
                    PhotoPath="" 
                },
                new Employee() { 
                    Id = 3, 
                    Name = "Sam", 
                    Department = Dept.Other, 
                    Email = "sam@pragimtech.com",
                    PhotoPath=""
                }

            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(m => m.Id == id);
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Update(Employee updateEmployee)
        {
            Employee employee = _employeeList.FirstOrDefault(m => m.Id == updateEmployee.Id);
            if (employee != null)
            {
                employee.Name=updateEmployee.Name;
                employee.Email = updateEmployee.Email;
                employee.Department = updateEmployee.Department;
            }
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(m => m.Id == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }
    }
}
