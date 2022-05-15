using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicLibraryApi.DataAccessLayer;
using MusicLibraryApi.Shared.Models;
using MusicLibraryApi.Shared.Models.Requests;
using Entities = MusicLibraryApi.DataAccessLayer.Entities;

namespace MusicLibraryApi.BusinessLayer.Services;

public class RecordLabelService : IRecordLabelService
{
    private readonly IDataContext dataContext;
    private readonly IMapper mapper;

    public RecordLabelService(IDataContext dataContext, IMapper mapper)
    {
        this.dataContext = dataContext;
        this.mapper = mapper;
    }

    public async Task DeleteAsync(Guid id)
    {
        var dbLabel = await dataContext.GetAsync<Entities.RecordLabel>(id);
        dataContext.Delete(dbLabel);
        await dataContext.SaveAsync();
    }
    public async Task<RecordLabel> GetAsync(Guid id)
    {
        var dbLabel = await dataContext.GetAsync<Entities.RecordLabel>(id);
        var label = mapper.Map<RecordLabel>(dbLabel);
        return label;
    }
    public async Task<RecordLabel> GetAsync(string name)
    {
        var dbLabel = await dataContext.GetQuery<Entities.RecordLabel>()
            .Where(r => r.Name == name)
            .FirstAsync();

        var label = mapper.Map<RecordLabel>(dbLabel);
        return label;
    }
    public async Task<RecordLabel> SaveAsync(SaveRecordLabelRequest request)
    {
        var query = dataContext.GetQuery<Entities.RecordLabel>(trackingChanges: true);
        var dbLabel = request.Id != null ? await query.Where(rl => rl.Id == request.Id)
            .FirstAsync() : null;

        if (dbLabel == null)
        {
            dbLabel = mapper.Map<Entities.RecordLabel>(request);
            dataContext.Insert(dbLabel);
        }
        else
        {
            mapper.Map(request, dbLabel);
        }

        await dataContext.SaveAsync();
        var savedRecordLabel = mapper.Map<RecordLabel>(dbLabel);
        return savedRecordLabel;
    }
}