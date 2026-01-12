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

        public User Find(int id)
        {
            return db.Users.Find(id);
        }

        public List<User> Find()
        {
            return db.Users.ToList();
        }

        public bool Create(User user)
        {
            if (FindByEmail(user.Email) != null)
                throw new System.Exception("Email already exists");

            if (FindByPhoneNumber(user.PhoneNumber) != null)
                throw new System.Exception("Phone number already exists");

            db.Users.Add(user);
            return db.SaveChanges() > 0;
        }


        public bool Delete(int id)
        {
            var dbUser = db.Users.Find(id);
            if (dbUser == null)
                return false;

            db.Users.Remove(dbUser);
            return db.SaveChanges() > 0;
        }

        public bool Update(User user)
        {
            var dbUser = Find(user.Id);
            if (dbUser == null)
                return false;

            dbUser.Name = user.Name;
            dbUser.Email = user.Email;
            dbUser.PhoneNumber = user.PhoneNumber;
            dbUser.Password = user.Password;
            dbUser.RoleId = user.RoleId;
            dbUser.IsActive = user.IsActive;
            return db.SaveChanges() > 0;

        }

        public User FindByEmail(string email)
        {
            return db.Users.FirstOrDefault(u => u.Email == email);
        }


        public User FindByPhoneNumber(string email)
        {
            return db.Users.FirstOrDefault(u => u.PhoneNumber == email);
        }


        public List<User> GetUsersWithRole()
        {
            return db.Users.Include(u => u.Role).ToList();
        }


    }
}
