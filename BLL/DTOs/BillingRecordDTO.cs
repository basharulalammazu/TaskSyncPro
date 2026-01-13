using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class BillingRecordDTO
    {
        public int TaskId { get; set; }
        public decimal Amount { get; set; }
        public int PaidById { get; set; } // Employee/User
    }
}
