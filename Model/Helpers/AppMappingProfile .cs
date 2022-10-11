using AutoMapper;
using Model.ViewModel;

namespace Model.Helpers
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Recruitment, PersonnelMovements>().ForMember(dest => dest.DateStart, opt => opt.MapFrom(src => src.Date));
            CreateMap<Dismissal, PersonnelMovements>();
            CreateMap<Transfer, PersonnelMovements>().ForMember(dest => dest.DateStart, opt => opt.MapFrom(src => src.Date));
        }
    }
}
