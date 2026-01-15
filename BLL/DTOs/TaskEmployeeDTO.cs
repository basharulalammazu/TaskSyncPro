using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class TaskEmployeeDTO : EmployeeDTO
    {
        public List<TaskDTO> tasks { set; get; }
        public TaskEmployeeDTO()
        {
            tasks = new List<TaskDTO>();
        }
    }
}
