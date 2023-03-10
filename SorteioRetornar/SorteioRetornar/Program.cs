using Microsoft.EntityFrameworkCore;
using SorteioRetornar.Infra.Data;
using SorteioRetornar.Infra.Data.Repositories;
using SorteioRetornar.Interfaces.Services;
using SorteioRetornar.Services;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();


void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlServer(connectionString);
    });

    builder.Services.AddScoped<IClientService, ClientService>();
    builder.Services.AddScoped<IRepository, Repository>();
}
