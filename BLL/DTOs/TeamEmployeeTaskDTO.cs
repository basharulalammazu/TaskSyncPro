using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class TeamEmployeeTaskDTO : TeamEmployeeDTO
    {
        public List<TaskDTO> tasks { set; get; }

        public TeamEmployeeTaskDTO()
        {
            tasks = new List<TaskDTO>();
        }
    }
}
