using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IEmployeeFeature : IRepository<Employee>
    {
      //  List<Employee> GetEmployeesWithTasks();
        public Employee GetEmployeeWithDetails(int id);
        public List<Employee> GetEmployeeWithDetails();

    }
}
