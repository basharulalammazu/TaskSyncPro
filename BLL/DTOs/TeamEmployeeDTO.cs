using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class TeamEmployeeDTO : TeamDTO
    {
        public List<EmployeeDTO> Employees { get; set; }

        public TeamEmployeeDTO()
        {
            Employees = new List<EmployeeDTO>();
        }
    }
}
