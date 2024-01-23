using AutoMapper;
using VisitorSecurityClearnceSystem.DTO;
using VisitorSecurityClearnceSystem.Entities;

namespace VisitorSecurityClearnceSystem.Common
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Manager ,AdminModel>().ReverseMap();
            CreateMap<Visitor,VisitorModel>().ReverseMap();
        }
    }
}
