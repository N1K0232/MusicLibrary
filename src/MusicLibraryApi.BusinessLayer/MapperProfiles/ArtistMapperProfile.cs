using AutoMapper;
using MusicLibraryApi.Shared.Models;
using MusicLibraryApi.Shared.Models.Requests;
using Entities = MusicLibraryApi.DataAccessLayer.Entities;

namespace MusicLibraryApi.BusinessLayer.MapperProfiles;

public class ArtistMapperProfile : Profile
{
    public ArtistMapperProfile()
    {
        CreateMap<Entities.Artist, Artist>();
        CreateMap<SaveArtistRequest, Entities.Artist>();
    }
}