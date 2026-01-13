using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IEmployeeFeature : IRepository<Employee>
    {
        List<Employee> GetEmployeesWithTasks();
        Employee GetEmployeeWithTasks(int id);
        Employee FindByUserEmail(string email);
    }
}
