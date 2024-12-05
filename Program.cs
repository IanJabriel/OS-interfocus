using Microsoft.EntityFrameworkCore;
using ApiCrud.src.Data;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do contexto do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura��o de servi�os
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Esperar o banco de dados estar acess�vel antes de aplicar as migrations
await WaitForDatabaseAsync(app.Services);

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate(); // Aplica as migrations
}

// Configura��o do middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

// Fun��o para esperar a disponibilidade do banco de dados
async Task WaitForDatabaseAsync(IServiceProvider services)
{
    var configuration = services.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");

    // Tentativa de conex�o com o banco de dados at� que ele esteja dispon�vel
    using var connection = new NpgsqlConnection(connectionString);
    var retries = 30;  // N�mero de tentativas
    var delay = TimeSpan.FromSeconds(10);  // Intervalo entre as tentativas

    while (retries > 0)
    {
        try
        {
            await connection.OpenAsync();
            break; // Conex�o bem-sucedida, sai do loop
        }
        catch (Exception)
        {
            retries--;
            if (retries == 0)
                throw; // Se esgotar o n�mero de tentativas, lan�a a exce��o
            await Task.Delay(delay); // Espera antes de tentar novamente
        }
    }
}
