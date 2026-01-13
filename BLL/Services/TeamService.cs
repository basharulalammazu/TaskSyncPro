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
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Team>(teamDTO);

            return dataAccessFactory.TeamDataAccess().Create(data);
        }


        public bool Delete(int id)
        {
            return dataAccessFactory.TeamDataAccess().Delete(id);
        }

        public TeamDTO Find(int id)
        {
            var data = dataAccessFactory.TeamDataAccess().Find(id);
            if (data == null) 
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<TeamDTO>(data);
        }


        public List<TeamDTO> Find()
        {
            var data = dataAccessFactory.TeamDataAccess().Find();   
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<TeamDTO>>(data);
        }


        public bool Update(TeamDTO teamDTO)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Team>(teamDTO);

            return dataAccessFactory.TeamDataAccess().Update(data);
        }

        public List<TeamDTO> GetTeamsWithEmployees()
        {
            var data = dataAccessFactory.TeamDataAccess().GetTeamsWithEmployees();

            var mapper = MapperConfig.GetMapper();
            return  mapper.Map<List<TeamDTO>>(data);
        }


    }
}
