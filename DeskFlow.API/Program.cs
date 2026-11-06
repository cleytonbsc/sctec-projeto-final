using DbApi.Middlewares;
using DeskFlow.API.Data;
using DeskFlow.API.Repositories;
using DeskFlow.API.Repositories.Interfaces;
using DeskFlow.API.Services;
using DeskFlow.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi(op =>
{
    op.AddDocumentTransformer((doc, _, _) =>
    {
        doc.Components.SecuritySchemes = new Dictionary<string, IOpenApiSecurityScheme>();
        doc.Components.SecuritySchemes["Bearer"] = new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "Identity access token",
            In = ParameterLocation.Header,
            Description = "Cole apenas o accessToken retornado por /auth/login. O Swagger adiciona 'Bearer' automaticamente."
        };
        return Task.CompletedTask;
    });

    op.AddOperationTransformer((operation, context, _) =>
    {
        if (context.Description.ActionDescriptor.EndpointMetadata.Any(metadata => metadata is IAuthorizeData))
        {
            operation.Security ??= [];
            operation.Security.Add(new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("Bearer", context.Document, null)] = []
            });
        }

        return Task.CompletedTask;
    });

});

builder.Services.AddControllers();


string connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("A string de conexão 'DefaultConnection' não foi encontrada.");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
       .AddRoles<IdentityRole>()
       .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthorization();

builder.Services.AddScoped<ICategoriasRepository, CategoriasRepository>();
builder.Services.AddScoped<ICategoriasService, CategoriasServices>();

builder.Services.AddScoped<IChamadosRepository, ChamadosRepository>();
builder.Services.AddScoped<IChamadosService, ChamadosService>();

builder.Services.AddScoped<IInteracoesRepository, InteracoesRepository>();
builder.Services.AddScoped<IInteracoesService, InteracoesService>();

var app = builder.Build();

app.UseMiddleware<ErrorMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

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

app.MapGroup("/auth").MapIdentityApi<IdentityUser>();

app.Run();