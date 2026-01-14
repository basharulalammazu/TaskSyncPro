using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ITeamFeature : IRepository<Team>
    {
        List<Team> GetTeamsWithEmployees();
        Team GetTeamWithEmployee(int id);
        List<Team> Find(string name);

    }
}
