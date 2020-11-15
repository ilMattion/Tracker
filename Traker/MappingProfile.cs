using AutoMapper;
using Tracker.DataAccess.Entities;
using Tracker.Services.Models;

namespace Tracker
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Document, DocumentDto>().ReverseMap();
            CreateMap<Document, DocumentFormDto>().ReverseMap();
            CreateMap<Process, ProcessDto>().ReverseMap();
            CreateMap<Process, ProcessFormDto>().ReverseMap();
        }
    }
}
