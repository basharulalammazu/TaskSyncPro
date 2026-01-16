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



        public bool Create(UserDTO userDTO)
        {
            if (userDTO == null)
                throw new ArgumentNullException(nameof(userDTO));

            if (dataAccessFactory.UserDataAccess().FindByEmail(userDTO.Email) != null)
                throw new ApplicationException("Email already exists.");

            if (dataAccessFactory.UserDataAccess().FindByPhoneNumber(userDTO.PhoneNumber) != null)
                throw new ApplicationException("Phone number already exists.");

            try
            {
                var mapper = MapperConfig.GetMapper();
                var user = mapper.Map<User>(userDTO);
                user.Password = PasswordGenerator.GeneratePassword(4);

                return dataAccessFactory.GetRepo<User>().Create(user) && EmailService.SendUserCredentials(user.Email, user.Name, user.Password, user.PhoneNumber);

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


        public List<UserDTO> Find()
        {
            var dbData = dataAccessFactory.GetRepo<User>().Find();
            if (dbData == null)
                return null;

            var mapper = MapperConfig.GetMapper();
            var dtoData = mapper.Map<List<UserDTO>>(dbData);
            return dtoData;

        }

        public UserDTO Find(int id)
        {
            var dbData = dataAccessFactory.GetRepo<User>().Find(id);
            if (dbData == null)
                return null;

            var mapper = MapperConfig.GetMapper();
            var dtoData = mapper.Map<UserDTO>(dbData);
            return dtoData;
        }


     

        public bool Update(UserDTO user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (Find(user.Id) == null)
                throw new InvalidOperationException("User not found.");

            if (dataAccessFactory.UserDataAccess().IsEmailAlreadyUsed(user.Id, user.Email))
                throw new InvalidOperationException("Email already exists.");

            if (dataAccessFactory.UserDataAccess().IsPhoneNumberAlreadyUsed(user.Id, user.PhoneNumber))
                throw new InvalidOperationException("Phone number already exists.");


            var mapper = MapperConfig.GetMapper();
            var dbUser = mapper.Map<User>(user);
            return dataAccessFactory.GetRepo<User>().Update(dbUser);
        }



        public bool Delete(int id)
        {
            if (Find(id) == null)
                throw new InvalidOperationException("User not found.");

            return dataAccessFactory.GetRepo<User>().Delete(id);
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
                return null;

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<UserRoleDTO>>(dbData);
        }

    }
}
