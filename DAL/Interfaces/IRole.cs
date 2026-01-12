using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRole : IRepository<Role>
    {
        List<Role> Find(string role);
    }
}
