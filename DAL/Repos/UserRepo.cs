using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class UserRepo : IUserFeature
    {
        private readonly TaskSyncDbContext db;
        public UserRepo(TaskSyncDbContext db)
        {
            this.db = db;
        }

        public User FindByEmailAndPassword(User user)
        {
            return (from u in db.Users.Include("Role")
                    where u.Email == user.Email && u.Password == user.Password
                    select u).SingleOrDefault();
        }


        public bool IsEmailAlreadyUsed(int id, string email)
        {
            return db.Users.Any(u => u.Email == email && u.Id != id);
        }

        public bool IsPhoneNumberAlreadyUsed(int id, string phoneNumber)
        {
            return db.Users.Any(u => u.PhoneNumber == phoneNumber && u.Id != id);
        }


        public User FindByEmail(string email)
        {
            return db.Users.FirstOrDefault(u => u.Email == email);
        }


        public User FindByPhoneNumber(string email)
        {
            return db.Users.FirstOrDefault(u => u.PhoneNumber == email);
        }


        public List<Role> GetUsersWithRole()
        {
            return db.Roles.Include(u => u.Users).ToList();
        }


    }
}
