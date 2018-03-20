using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MVVMdemo.Models;
namespace MVVMdemo.Services
{
    public class EmployeesServices
    {
        public ObservableCollection<Employee> GetEmployees()
        {
            var List = new ObservableCollection<Employee>
            {
                new Employee
                {
                    Name="Mohamed",
                    Department="Marketing"
                },
                new Employee
                {
                    Name = "Arsen",
                    Department="Design"
                },
                new Employee
                {
                    Name="Pedro",
                    Department="Development"
                },
                new Employee
                {
                    Name = "George",
                    Department="Police"
                }
            };
            return List;
        }
    }
}
