using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Polaris.Usuario.Configs;
using Polaris.Usuario.Context;
using Polaris.Usuario.ExternalServices;
using Polaris.Usuario.Repository;
using Polaris.Usuario.Services;
using Polaris.Usuario.ViewModels.Mappings;
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
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IEnderecoExternalService, EnderecoExternalService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.Configure<ExternalConfigs>(builder.Configuration.GetSection("ExternalConfigs"));

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
