using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IEmployeeFeature
    {
      //  List<Employee> GetEmployeesWithTasks();
        public Employee GetEmployeeWithDetails(int id);
        public List<Employee> GetEmployeeWithDetails();
        public Employee FindByUserPhoneNumber(string phoneNumber);
        public Employee FindByUserEmail(string email);
        public bool ExistsForUser(int userId);
        public bool ExistsForTeamDesignation(int teamId, string designation);
    }
}
