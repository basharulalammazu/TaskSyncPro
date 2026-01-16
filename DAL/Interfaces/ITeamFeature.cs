using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ITeamFeature 
    {
        List<Team> GetTeamsWithEmployees();
        Team GetTeamWithEmployee(int id);
        public List<Team> Find(string name);
        public bool Find(int id, string name);
        public Team SearchByName(string name);
        public Team GetTeamWithEmployeeTask(int id);
        public List<Team> GetTeamWithEmployeeTask();

    }
}
