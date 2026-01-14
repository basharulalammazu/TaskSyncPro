using AutoMapper;
using BLL.DTOs;
using BLL.Helpers;
using DAL;
using DAL.EF.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        DataAccessFactory dataAccessFactory;

        public UserService(DataAccessFactory dataAccessFactory)
        {
            this.dataAccessFactory = dataAccessFactory;
        }


        public async Task<UserDTO> LoginAsync(UserLoginDTO loginDTO)
        {
            var mapper = MapperConfig.GetMapper();
            var dto = mapper.Map<User>(loginDTO);
            dto.Password = PasswordGenerator.GeneratePassword();
            var user =  dataAccessFactory.UserDataAccess().FindByEmailAndPassword(dto);
            if (user == null)
                return null;

            return mapper.Map<UserDTO>(user);
        }


        public List<UserDTO> Find()
        {
            var dbData = dataAccessFactory.UserDataAccess().Find();
            if (dbData == null)
                return null;

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



        public bool Create(UserDTO userDTO)
        {
            if (userDTO == null)
                throw new ArgumentNullException(nameof(userDTO));


            try
            {
                var mapper = MapperConfig.GetMapper();
                var user = mapper.Map<User>(userDTO);
                user.Password = PasswordGenerator.GeneratePassword(4);

                return dataAccessFactory.UserDataAccess().Create(user) && EmailService.SendUserCredentials(user.Email, user.Name, user.Password, user.PhoneNumber);

            }
            catch (InvalidOperationException ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("User creation failed.", ex);
            }
        }



        public bool Delete(int id)
        {
            return dataAccessFactory.UserDataAccess().Delete(id);
        }

        public bool Update(UserDTO user)
        {
            try
            {
                var mapper = MapperConfig.GetMapper();
                var dbUser = mapper.Map<User>(user);
                return dataAccessFactory.UserDataAccess().Update(dbUser);
            }

            catch 
            {
                throw ;
            }
            

        }

        public UserDTO FindByEmail(string email)
        {
            var dbData = dataAccessFactory.UserDataAccess().FindByEmail(email);
            if (dbData == null)
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<UserDTO>(dbData);   
        }


        public UserDTO FindByPhoneNumber(string phoneNumber)
        {
            var dbData = dataAccessFactory.UserDataAccess().FindByPhoneNumber(phoneNumber);
            if (dbData == null)
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<UserDTO>(dbData);
        }


        public List<UserRoleDTO> GetUsersWithRole()
        {
            var dbData = dataAccessFactory.UserDataAccess().GetUsersWithRole();

            if (dbData == null || dbData.Count == 0)
                return new List<UserRoleDTO>();

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<UserRoleDTO>>(dbData);
        }

    }
}
