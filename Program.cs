using CooperativaAPI.Data;
using CooperativaAPI.Services.Implementations;
using CooperativaAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "Cooperativa API",
            Version = "v1",
            Description = "API para gerenciamento de cooperados e contatos favoritos",
        }
    );
});

// Configure CORS with a named policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowFrontend",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:3000") // Frontend URL
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    );
});

// Configure Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<ICooperativaService, CooperativaService>();
builder.Services.AddScoped<ICooperadoService, CooperadoService>(); // <- Adicione esta linha
builder.Services.AddScoped<IContatoFavoritoService, ContatoFavoritoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cooperativa API V1");
        c.RoutePrefix = "swagger";
    });
}

app.UseRouting();

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Urls.Add("http://localhost:5000");
app.Urls.Add("https://localhost:5001");

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider.GetService<ICooperativaService>();
    Console.WriteLine(
        service == null ? "❌ Serviço não registrado" : "✅ Serviço registrado corretamente"
    );
}

app.Run();
