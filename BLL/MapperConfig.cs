using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MapperConfig
    {
        static MapperConfiguration cfg = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<BillingRecord, BillingRecordDTO>().ReverseMap();
            cfg.CreateMap<Employee, EmployeeDTO>().ReverseMap();
            cfg.CreateMap<Role, RoleDTO>().ReverseMap();
            cfg.CreateMap<DAL.EF.Models.Task, TaskDTO>().ReverseMap();
            cfg.CreateMap<Team, TeamDTO>().ReverseMap();
            cfg.CreateMap<User, UserDTO>().ReverseMap();
            cfg.CreateMap<User,UserLoginDTO>().ReverseMap();

            cfg.CreateMap<Role, UserRoleDTO>().ReverseMap();
            cfg.CreateMap<Team, TeamEmployeeDTO>().ReverseMap();
            cfg.CreateMap<Employee, EmployeeDetailsDTO>().ReverseMap();
            cfg.CreateMap<DAL.EF.Models.Task, TaskEmployeeDTO>().ReverseMap();

        });
        public static Mapper GetMapper()
        {
            return new Mapper(cfg);
        }
    }

}
