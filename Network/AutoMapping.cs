using AutoMapper;
using Network.DTO.Application;

namespace Network
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Domain.Models.Application, AddApplicationViewModel>().ReverseMap();
        }
    }
}
