using FluentValidation.AspNetCore;
using Hellang.Middleware.ProblemDetails;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using MusicLibraryApi.BusinessLayer.MapperProfiles;
using MusicLibraryApi.BusinessLayer.Services;
using MusicLibraryApi.BusinessLayer.Validators;
using MusicLibraryApi.DataAccessLayer;
using Serilog;
using System.Text.Json.Serialization;
using TinyHelpers.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
});
builder.Services.AddProblemDetails();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        options.JsonSerializerOptions.Converters.Add(new UtcDateTimeConverter());
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddAutoMapper(typeof(SongMapperProfile).Assembly);
builder.Services.AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblyContaining<SaveSongRequestValidator>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen()
    .AddFluentValidationRulesToSwagger(options =>
{
    options.SetNotNullableIfMinLengthGreaterThenZero = true;
});

string connectionString = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddSqlServer<DataContext>(connectionString);
builder.Services.AddScoped<IDataContext>(sp => sp.GetRequiredService<DataContext>());

builder.Services.AddScoped<IRecordLabelService, RecordLabelService>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<ISongService, SongService>();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseProblemDetails();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();