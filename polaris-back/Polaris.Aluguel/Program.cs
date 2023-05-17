using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Polaris.Aluguel.Context;
using Polaris.Aluguel.ExternalServices;
using Polaris.Aluguel.Repository;
using Polaris.Aluguel.Services;
using Polaris.Aluguel.ViewModels.Mappings;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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
builder.Services.AddScoped<IAluguelRepository, AluguelRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IConteinerRepository, ConteinerRepository>();
builder.Services.AddScoped<IAlugueisService, AlugueisService>();
builder.Services.AddScoped<IEnderecoExternalService, EnderecoExternalService>();
builder.Services.AddScoped<IConteinerExternalService, ConteinerExternalService>();
builder.Services.AddScoped<IClienteExternalService, ClienteExternalService>();

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