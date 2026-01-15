using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUserFeature 
    {
        User FindByEmailAndPassword(User user);
        User FindByEmail(string email);
        User FindByPhoneNumber(string phoneNumber);
        List<Role> GetUsersWithRole();
        public bool IsEmailAlreadyUsed(int id, string email);
        public bool IsPhoneNumberAlreadyUsed(int id, string phoneNumber);
    }
}
