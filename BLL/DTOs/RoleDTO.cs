using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BLL.DTOs
{
    public class RoleDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Role name is required.")]
        public string Name { get; set; }   // Admin, Manager, Employee
    }
}
