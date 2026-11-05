using DeskFlow.API.Data;
using DeskFlow.API.Repositories;
using DeskFlow.API.Repositories.Interfaces;
using DeskFlow.API.Services;
using DeskFlow.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi();
builder.Services.AddControllers();


string connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("A string de conexão 'DefaultConnection' não foi encontrada.");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));



builder.Services.AddScoped<ICategoriasRepository, CategoriasRepository>();
builder.Services.AddScoped<ICategoriasService, CategoriasServices>();

builder.Services.AddScoped<IChamadosRepository, ChamadosRepository>();
builder.Services.AddScoped<IChamadosService, ChamadosService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI( op =>
    {
        op.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}


app.MapControllers();

app.Run();