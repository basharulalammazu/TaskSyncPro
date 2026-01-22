using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IReports
    {
        public List<EF.Models.Task> GetTasks(DateTime from, DateTime to);
        public List<Employee> GetEmployeesWithTasks(DateTime from, DateTime to);
        public List<Team> GetTeamsWithTasks(DateTime from, DateTime to);
    }
}
