
using Domain.Interfaces.IFavorite;

using Infra.Configuracao;
using Infra.Repositorio;

using Microsoft.EntityFrameworkCore;

using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>(options =>
    options.UseSqlite("FileName=database", option => {
        option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
    }));

builder.Services.AddSingleton<InterfaceFavorite, RepositorioFavorite>();

var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

var devClient = "http://localhost:3000"; // Altere para a origem do seu frontend
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins(devClient));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
