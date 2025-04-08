using CooperativaAPI.Data;
using CooperativaAPI.Services.Interfaces;
using CooperativaAPI.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICooperativaService, CooperativaService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Cooperativa API",
        Version = "v1",
        Description = "API para gerenciamento de cooperados e contatos favoritos"
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();




using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider.GetService<ICooperativaService>();
    Console.WriteLine(service == null ? "❌ Serviço não registrado" : "✅ Serviço registrado corretamente");
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cooperativa API V1");
        c.RoutePrefix = "swagger";
    });
}
app.UseHttpsRedirection();
app.Urls.Add("http://localhost:5000");
app.UseAuthorization();
app.MapControllers();

app.Run();