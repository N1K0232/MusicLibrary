using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicLibraryApi.DataAccessLayer;
using MusicLibraryApi.Shared.Models;
using MusicLibraryApi.Shared.Models.Requests;
using Entities = MusicLibraryApi.DataAccessLayer.Entities;

namespace MusicLibraryApi.BusinessLayer.Services;

public class ArtistService : IArtistService
{
    private readonly IRecordLabelService recordLabelService;
    private readonly IDataContext dataContext;
    private readonly IMapper mapper;

    public ArtistService(IRecordLabelService recordLabelService, IDataContext dataContext, IMapper mapper)
    {
        this.recordLabelService = recordLabelService;
        this.dataContext = dataContext;
        this.mapper = mapper;
    }

    public async Task DeleteAsync(Guid id)
    {
        var dbArtist = await dataContext.GetAsync<Entities.Artist>(id);
        dataContext.Delete(dbArtist);
        await dataContext.SaveAsync();
    }
    public async Task<Artist> GetAsync(Guid id)
    {
        var dbArtist = await dataContext.GetAsync<Entities.Artist>(id);
        var artist = mapper.Map<Artist>(dbArtist);
        artist.RecordLabel = await recordLabelService.GetAsync(dbArtist.IdLabel);
        return artist;
    }
    public async Task<Artist> GetAsync(string artName)
    {
        var dbArtist = await dataContext.GetQuery<Entities.Artist>()
            .Where(a => a.ArtName == artName)
            .FirstAsync();

        var artist = mapper.Map<Artist>(dbArtist);
        artist.RecordLabel = await recordLabelService.GetAsync(dbArtist.IdLabel);
        return artist;
    }
    public async Task<Artist> SaveAsync(SaveArtistRequest request)
    {
        var query = dataContext.GetQuery<Entities.Artist>(trackingChanges: true);
        var dbArtist = request.Id != null ? await query.Where(a => a.Id == request.Id)
            .FirstAsync() : null;

        if (dbArtist == null)
        {
            dbArtist = mapper.Map<Entities.Artist>(request);
            dataContext.Insert(dbArtist);
        }
        else
        {
            mapper.Map(request, dbArtist);
        }

        await dataContext.SaveAsync();
        var savedArtist = mapper.Map<Artist>(dbArtist);
        savedArtist.RecordLabel = await recordLabelService.GetAsync(dbArtist.IdLabel);
        return savedArtist;
    }
}