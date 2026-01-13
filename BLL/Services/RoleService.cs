using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class RoleService
    {
        DataAccessFactory dataAccessFactory;

        public RoleService(DataAccessFactory dataAccessFactory)
        {
            this.dataAccessFactory = dataAccessFactory;
        }


        public bool Create(RoleDTO entity)
        {
            var mapper = MapperConfig.GetMapper();
            var role = mapper.Map<Role>(entity);
            var success = dataAccessFactory.RoleDataAccess().Create(role);

            if (!success)
                return false;

            return true;
        }


        public bool Delete(int id)
        {
           return dataAccessFactory.RoleDataAccess().Delete(id);
        }

        public RoleDTO Find(int id)
        {
            var dbData = dataAccessFactory.RoleDataAccess().Find(id);
            if (dbData == null) 
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<RoleDTO>(dbData);
        }


        public List<RoleDTO> Find()
        {
            var dbData = dataAccessFactory.RoleDataAccess().Find();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<RoleDTO>>(dbData);
        }


        public List<RoleDTO> Find(string role)
        {
            var dbData = dataAccessFactory.RoleDataAccess().Find(role);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<RoleDTO>>(dbData);

        }

        public bool Update(Role entity)
        {
            return dataAccessFactory.RoleDataAccess().Update(entity);
        }
    }
}
