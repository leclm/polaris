using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Polaris.Servico.Configs;
using Polaris.Servico.Context;
using Polaris.Servico.ExternalServices;
using Polaris.Servico.Repository;
using Polaris.Servico.Services;
using Polaris.Servico.ViewModels.Mappings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

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
builder.Services.AddScoped<IServicosService, ServicosService>();
builder.Services.AddScoped<ITerceirizadosService, TerceirizadosService>();
builder.Services.AddScoped<IEnderecoExternalService, EnderecoExternalService>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();

builder.Services.Configure<ExternalConfigs>(builder.Configuration.GetSection("ExternalConfigs"));

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirAngularRequest",
        builder =>
        builder.WithOrigins("http://localhost:4200"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(opt => opt.WithOrigins("http://localhost:4200"));

app.MapControllers();

app.Run();
