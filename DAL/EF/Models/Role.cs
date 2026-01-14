using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }   // Admin, Manager, Employee

        public virtual List<User> Users { get; set; }

        public Role()
        {
            Users = new List<User>();
        }

    }
}
