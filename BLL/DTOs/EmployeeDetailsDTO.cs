using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class EmployeeDetailsDTO
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public bool IsAvailable { get; set; }

        public UserDTO User { get; set; }
        public TeamDTO Team { get; set; }
        public List<TaskDTO> Tasks { get; set; }

        public EmployeeDetailsDTO() 
        {
            Tasks = new List<TaskDTO>();
        }
    }
}
