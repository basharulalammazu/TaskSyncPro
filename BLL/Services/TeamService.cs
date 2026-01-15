using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class TeamService
    {
        DataAccessFactory dataAccessFactory;

        public TeamService(DataAccessFactory dataAccessFactory)
        {
            this.dataAccessFactory = dataAccessFactory;
        }


        public bool Create(TeamDTO teamDTO)
        {
            if (dataAccessFactory.TeamDataAccess().SearchByName(teamDTO.Name) != null)
                throw new Exception("Team with the same name already exists.");

            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Team>(teamDTO);

            return dataAccessFactory.GetRepo<Team>().Create(data);
        }

        public List<TeamDTO> Find()
        {
            var data = dataAccessFactory.GetRepo<Team>().Find();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<TeamDTO>>(data);
        }

        public TeamDTO Find(int id)
        {
            var data = dataAccessFactory.GetRepo<Team>().Find(id);
            if (data == null) 
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<TeamDTO>(data);
        }

        public bool Update(TeamDTO teamDTO)
        {
            if (Find(teamDTO.Id) == null)
                throw new Exception("Team is not found with this id");

            if (dataAccessFactory.TeamDataAccess().Find(teamDTO.Id, teamDTO.Name))
                throw new Exception("Team with the same name already exists.");
            
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Team>(teamDTO);

            return dataAccessFactory.GetRepo<Team>().Update(data);
        }


        public bool Delete(int id)
        {
            if (Find(id) == null)
                throw new Exception("Team is not found with this id");

            return dataAccessFactory.GetRepo<Team>().Delete(id);
        }

        public List<TeamEmployeeDTO> GetTeamsWithEmployees()
        {
            var data = dataAccessFactory.TeamDataAccess().GetTeamsWithEmployees();

            var mapper = MapperConfig.GetMapper();
            return  mapper.Map<List<TeamEmployeeDTO>>(data);
        }



        public TeamEmployeeDTO GetTeamsWithEmployees(int id)
        {
            var data = dataAccessFactory.TeamDataAccess().GetTeamWithEmployee(id);

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<TeamEmployeeDTO>(data);
        }
    }
}
