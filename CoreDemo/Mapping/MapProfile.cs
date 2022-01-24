using AutoMapper;
using CoreDemo.Models;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Writer, AddProfileImage>().ReverseMap();
        }
    }
}
