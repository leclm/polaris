using System.Reflection;
using System;
using Polaris.Conteiner.Context;
using Microsoft.EntityFrameworkCore;
using Polaris.Conteiner.Repository;
using Polaris.Conteiner.Services;
using AutoMapper;
using Polaris.Conteiner.ViewModels.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseMySql(mySqlConnection,
                    ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();
builder.Services.AddScoped<ITipoConteinerRepository, TipoConteinerRepository>();
builder.Services.AddScoped<ICategoriaConteinerRepository, CategoriaConteinerRepository>();
builder.Services.AddScoped<IConteinerRepository, ConteinerRepository>();
builder.Services.AddScoped<ICategoriasConteinerService, CategoriasConteinerService>();
builder.Services.AddScoped<IConteineresService, ConteineresService>();
builder.Services.AddScoped<ITiposConteineresService, TiposConteineresService>();


var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});


IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.MapControllers();

app.Run();
