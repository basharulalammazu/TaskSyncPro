using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ITeamFeature : IRepository<Team>
    {
        List<Team> GetTeamsWithEmployees();
        Team GetTeamWithEmployees(int id);
    }
}
