using AutoMapper;
using MusicLibraryApi.Shared.Models;
using MusicLibraryApi.Shared.Models.Requests;
using Entities = MusicLibraryApi.DataAccessLayer.Entities;

namespace MusicLibraryApi.BusinessLayer.MapperProfiles;

public class RecordLabelMapperProfile : Profile
{
    public RecordLabelMapperProfile()
    {
        CreateMap<Entities.RecordLabel, RecordLabel>();
        CreateMap<SaveRecordLabelRequest, Entities.RecordLabel>();
    }
}