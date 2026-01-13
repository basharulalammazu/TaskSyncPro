using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class TeamReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Employees { get; set; } // Employee names
    }
}
