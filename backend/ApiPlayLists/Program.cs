using ApiPlayLists.AppData;
using ApiPlayLists.Repositories;
using ApiPlayLists.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Conexión a la base de datos
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        npgsql =>
        {
            npgsql.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(5),
                errorCodesToAdd: null);
        }
    )
);

// Agregar servicios y repositorios
builder.Services.AddScoped<IPlayListRepository, PlayListRepositoryImpl>();
builder.Services.AddScoped<PlayListService>();
builder.Services.AddScoped<ISongRepository, SongRepositoryImpl>();
builder.Services.AddScoped<SongService>();
builder.Services.AddScoped<ISongAudioRepository, SongAudioRespositoryImpl>();
builder.Services.AddScoped<SongAudioService>();
builder.Services.AddScoped<ISongCoverRepository, SongCoverRepositoryImpl>();
builder.Services.AddScoped<SongCoverService>();
builder.Services.AddScoped<IPlayListCoverRepository, PlayListCoverImpl>();
builder.Services.AddScoped<PlayListCoverService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => { 
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Run();