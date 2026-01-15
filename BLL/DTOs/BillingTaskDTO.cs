using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class BillingTaskDTO : BillingRecordDTO
    {
        public TaskDTO task { set; get;  }

        public BillingTaskDTO()
        {
            task = new TaskDTO();
        }
    }
}
