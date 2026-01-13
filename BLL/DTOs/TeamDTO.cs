using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class TeamDTO
    {
        [Required(ErrorMessage = "Team name is required")]
        public string Name { get; set; }
    }
}
