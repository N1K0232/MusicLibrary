using AutoMapper;
using MusicLibraryApi.Shared.Models;
using MusicLibraryApi.Shared.Models.Requests;
using Entities = MusicLibraryApi.DataAccessLayer.Entities;

namespace MusicLibraryApi.BusinessLayer.MapperProfiles;

public class SongMapperProfile : Profile
{
    public SongMapperProfile()
    {
        CreateMap<Entities.Song, Song>();
        CreateMap<SaveSongRequest, Entities.Song>();
    }
}