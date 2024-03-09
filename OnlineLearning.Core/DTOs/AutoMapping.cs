using AutoMapper;
using OnlineLearning.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Core.DTOs
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
