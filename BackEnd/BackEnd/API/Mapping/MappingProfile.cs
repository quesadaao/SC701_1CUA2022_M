using AutoMapper;
using data = DAL.DO.Objects;

namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<data.Categories, DataModels.Categories>().ReverseMap();
            CreateMap<data.Products, DataModels.Products>().ReverseMap();
            CreateMap<data.Suppliers, DataModels.Suppliers>().ReverseMap();            
        }
    }
}
