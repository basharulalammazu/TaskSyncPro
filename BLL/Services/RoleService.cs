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
            if (dataAccessFactory.RoleDataAccess().Find(entity.Name).Count > 0)
                throw new Exception("Role already exists");



            var mapper = MapperConfig.GetMapper();
            var role = mapper.Map<Role>(entity);
            var success = dataAccessFactory.GetRepo<Role>().Create(role);

            if (!success)
                return false;

            return true;
        }
       

        public RoleDTO Find(int id)
        {
            var dbData = dataAccessFactory.GetRepo<Role>().Find(id);
            if (dbData == null) 
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<RoleDTO>(dbData);
        }   


        public List<RoleDTO> Find()
        {
            var dbData = dataAccessFactory.GetRepo<Role>().Find();
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
            if (Find(entity.Id) == null)
                throw new Exception("Role not found");

            if (Find(entity.Name).Count > 0)
                throw new Exception("Role name already exists");

            return dataAccessFactory.GetRepo<Role>().Update(entity);
        }

        public bool Delete(int id)
        {
            if (dataAccessFactory.GetRepo<Role>().Find(id) == null)
                throw new Exception("Role not found");

            return dataAccessFactory.GetRepo<Role>().Delete(id);
        }
    }
}
