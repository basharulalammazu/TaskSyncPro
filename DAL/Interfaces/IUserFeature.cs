using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUserFeature : IRepository<User>
    {
        User FindByEmail(string email);
        User FindByPhoneNumber(string phoneNumber);
        List<User> GetUsersWithRole();
    }
}
