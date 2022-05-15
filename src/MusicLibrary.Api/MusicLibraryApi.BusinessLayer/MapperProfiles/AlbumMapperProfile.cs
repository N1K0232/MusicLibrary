using AutoMapper;
using MusicLibraryApi.Shared.Models;
using MusicLibraryApi.Shared.Models.Requests;
using Entities = MusicLibraryApi.DataAccessLayer.Entities;

namespace MusicLibraryApi.BusinessLayer.MapperProfiles;

public class AlbumMapperProfile : Profile
{
    public AlbumMapperProfile()
    {
        CreateMap<Entities.Album, Album>();
        CreateMap<SaveAlbumRequest, Entities.Album>();
    }
}