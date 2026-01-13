using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BLL.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int TeamId { get; set; }

        public string Designation { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
