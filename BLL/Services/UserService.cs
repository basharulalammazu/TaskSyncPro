using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class UserService
    {
        DataAccessFactory dataAccessFactory;

        public UserService(DataAccessFactory dataAccessFactory)
        {
            this.dataAccessFactory = dataAccessFactory;
        }


        public List<UserDTO> Find()
        {
            var dbData = dataAccessFactory.UserDataAccess().Find();
            var mapper = MapperConfig.GetMapper();
            var dtoData = mapper.Map<List<UserDTO>>(dbData);
            return dtoData;

        }

        public UserDTO Find(int id)
        {
            var dbData = dataAccessFactory.UserDataAccess().Find(id);
            if (dbData == null)
                return null;

            var mapper = MapperConfig.GetMapper();
            var dtoData = mapper.Map<UserDTO>(dbData);
            return dtoData;
        }



        public (bool IsSuccess, string ErrorMessage) Create(UserDTO user)
        {
            try
            {
                var mapper = MapperConfig.GetMapper();
                var dbUser = mapper.Map<User>(user);
                var success = dataAccessFactory.UserDataAccess().Create(dbUser);
                return (success, null);
            }
            catch (UserValidationException ex)
            {
                return (false, ex.Message);
            }
            catch (Exception ex)
            {
                return (false, "An unexpected error occurred.");
            }
        }


        public bool Delete(int id)
        {
            return dataAccessFactory.UserDataAccess().Delete(id);
        }

        public bool Update(UserDTO user)
        {
            var mapper = MapperConfig.GetMapper();
            var dbUser = mapper.Map<User>(user);
            return dataAccessFactory.UserDataAccess().Update(dbUser);

        }

        public UserDTO FindByEmail(string email)
        {
            var dbData = dataAccessFactory.UserDataAccess().FindByEmail(email);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<UserDTO>(dbData);   
        }


        public UserDTO FindByPhoneNumber(string phoneNumber)
        {
            var dbData = dataAccessFactory.UserDataAccess().FindByPhoneNumber(phoneNumber);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<UserDTO>(dbData);
        }


        public List<UserDTO> GetUsersWithRole()
        {
            var dbData = dataAccessFactory.UserDataAccess().GetUsersWithRole();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<UserDTO>>(dbData);
        }
    }
}
