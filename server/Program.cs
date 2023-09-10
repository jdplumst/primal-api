using Microsoft.EntityFrameworkCore;
using PrimalAPI.GraphQL.Queries;
using PrimalAPI.Helpers;
using PrimalAPI.Interfaces;
using PrimalAPI.Models;
using PrimalAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddGraphQLServer()
    .AddMaxExecutionDepthRule(5)
    .RegisterService<IPokemonRepository>()
    .RegisterService<ISizeRepository>()
    .RegisterService<IHabitatRepository>()
    .RegisterService<IRarityRepository>()
    .RegisterService<IResourceMaker>()
    .AddQueryType<Query>()
    .AddTypeExtension<PokemonQuery>()
    .AddTypeExtension<SizeQuery>()
    .AddTypeExtension<HabitatQuery>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<ISizeRepository, SizeRepository>();
builder.Services.AddScoped<IHabitatRepository, HabitatRepository>();
builder.Services.AddScoped<IWeightRepository, WeightRepository>();
builder.Services.AddScoped<IRarityRepository, RarityRepository>();
builder.Services.AddScoped<IResourceMaker, ResourceMaker>();

builder.Services.AddCors();

DotNetEnv.Env.Load();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_URL")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors((o) => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.Run();
