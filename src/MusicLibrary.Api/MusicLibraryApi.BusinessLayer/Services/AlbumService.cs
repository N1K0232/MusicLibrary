using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicLibraryApi.DataAccessLayer;
using MusicLibraryApi.Shared.Models;
using MusicLibraryApi.Shared.Models.Requests;
using Entities = MusicLibraryApi.DataAccessLayer.Entities;

namespace MusicLibraryApi.BusinessLayer.Services;

public class AlbumService : IAlbumService
{
    private readonly IArtistService artistService;
    private readonly IDataContext dataContext;
    private readonly IMapper mapper;

    public AlbumService(IArtistService artistService, IDataContext dataContext, IMapper mapper)
    {
        this.artistService = artistService;
        this.dataContext = dataContext;
        this.mapper = mapper;
    }

    public async Task DeleteAsync(Guid id)
    {
        var dbAlbum = await dataContext.GetAsync<Entities.Album>(id);
        dataContext.Delete(dbAlbum);
        await dataContext.SaveAsync();
    }
    public async Task<Album> GetAsync(Guid id)
    {
        var dbAlbum = await dataContext.GetAsync<Entities.Album>(id);
        var album = mapper.Map<Album>(dbAlbum);
        album.Artist = await artistService.GetAsync(dbAlbum.IdArtist);
        return album;
    }
    public async Task<Album> GetAsync(string name)
    {
        var dbAlbum = await dataContext.GetQuery<Entities.Album>()
            .Where(a => a.Name == name)
            .FirstAsync();

        var album = mapper.Map<Album>(dbAlbum);
        album.Artist = await artistService.GetAsync(dbAlbum.IdArtist);
        return album;
    }
    public async Task<Album> SaveAsync(SaveAlbumRequest request)
    {
        var query = dataContext.GetQuery<Entities.Album>(trackingChanges: true);
        var dbAlbum = request.Id != null ? await query.FirstOrDefaultAsync(a => a.Id == request.Id) : null;

        if (dbAlbum == null)
        {
            dbAlbum = mapper.Map<Entities.Album>(request);
            dataContext.Insert(dbAlbum);
        }
        else
        {
            mapper.Map(request, dbAlbum);
        }

        await dataContext.SaveAsync();

        var savedAlbum = mapper.Map<Album>(dbAlbum);
        savedAlbum.Artist = await artistService.GetAsync(dbAlbum.IdArtist);
        return savedAlbum;
    }
}