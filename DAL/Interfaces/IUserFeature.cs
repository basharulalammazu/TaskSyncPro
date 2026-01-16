using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUserFeature 
    {
        User FindByEmailAndPassword(User user);
        public bool IsEmailAlreadyUsed(int id, string email);
        public bool IsPhoneNumberAlreadyUsed(int id, string phoneNumber);
        User FindByEmail(string email);
        User FindByPhoneNumber(string phoneNumber);
        List<Role> GetUsersWithRole();       
    }
}
