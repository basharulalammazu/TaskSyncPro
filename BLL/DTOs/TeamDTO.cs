using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class TeamDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Team name is required")]
        public string Name { get; set; }
    }
}
