using Microsoft.EntityFrameworkCore;
using ApiCrud.src.Data;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

await WaitForDatabaseAsync(app.Services);

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();

async Task WaitForDatabaseAsync(IServiceProvider services)
{
    var configuration = services.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");

    using var connection = new NpgsqlConnection(connectionString);
    var retries = 30;
    var delay = TimeSpan.FromSeconds(10);

    while (retries > 0)
    {
        try
        {
            await connection.OpenAsync();
            break;
        }
        catch (Exception)
        {
            retries--;
            if (retries == 0)
                throw;
            await Task.Delay(delay);
        }
    }
}
