using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicLibraryApi.DataAccessLayer;
using MusicLibraryApi.Shared.Models;
using MusicLibraryApi.Shared.Models.Requests;
using Entities = MusicLibraryApi.DataAccessLayer.Entities;

namespace MusicLibraryApi.BusinessLayer.Services;

public class SongService : ISongService
{
    private readonly IRecordLabelService recordLabelService;
    private readonly IArtistService artistService;
    private readonly IDataContext dataContext;
    private readonly IMapper mapper;

    public SongService(IRecordLabelService recordLabelService, IArtistService artistService, IDataContext dataContext, IMapper mapper)
    {
        this.recordLabelService = recordLabelService;
        this.artistService = artistService;
        this.dataContext = dataContext;
        this.mapper = mapper;
    }

    public async Task DeleteAsync(Guid id)
    {
        var dbSong = await dataContext.GetAsync<Entities.Song>(id);
        dataContext.Delete(dbSong);
        await dataContext.SaveAsync();
    }
    public async Task<Song> GetAsync(string title)
    {
        var dbSong = await dataContext.GetQuery<Entities.Song>()
            .Where(s => s.Title == title)
            .FirstAsync();

        var song = mapper.Map<Song>(dbSong);
        var artist = await artistService.GetAsync(dbSong.IdArtist);
        var recordLabel = await recordLabelService.GetAsync(dbSong.IdLabel);
        song.Artist = artist;
        song.RecordLabel = recordLabel;
        return song;
    }
    public async Task<Song> SaveAsync(SaveSongRequest request)
    {
        var query = dataContext.GetQuery<Entities.Song>(trackingChanges: true);
        var dbSong = request.Id != null ?
            await query.Where(s => s.Id == request.Id).FirstAsync() : null;

        if (dbSong == null)
        {
            dbSong = mapper.Map<Entities.Song>(request);
            dataContext.Insert(dbSong);
        }
        else
        {
            mapper.Map(request, dbSong);
        }

        await dataContext.SaveAsync();

        var savedSong = mapper.Map<Song>(dbSong);
        var artist = await artistService.GetAsync(dbSong.IdArtist);
        var recordLabel = await recordLabelService.GetAsync(dbSong.IdLabel);
        savedSong.Artist = artist;
        savedSong.RecordLabel = recordLabel;
        return savedSong;
    }
}