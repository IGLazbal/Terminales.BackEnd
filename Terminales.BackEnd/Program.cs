using Microsoft.EntityFrameworkCore;
using Terminales.Backend.Contracts.Services;
using Terminales.Backend.Contracts;
using Terminales.Backend.Persistence;
using Terminales.Backend.Services;
using Terminales.Backend.Contracts.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

EnsureDatabaseCreation(app);

ConfigurePipeline(app);

app.Run();

static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();
    services.AddMemoryCache();

    services.AddScoped<IUnitOfWork, UnitOfWork>();
    services.AddTransient<ITerminalService, TerminalService>();

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(configuration.GetConnectionString("TerminalesSQLServer"));
    });
}

static void EnsureDatabaseCreation(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<AppDbContext>();

        // Verificar si la base de datos ya existe
        if (!dbContext.Database.CanConnect())
        {
            dbContext.Database.EnsureCreated();
            SeedData(dbContext);
        }
    }
}


static void SeedData(AppDbContext dbContext)
{
    Fabricante fabricante1 = new Fabricante
    {
        Name = "fabricante 1",
        Description = "descripcion fabricante 1"
    };

    dbContext.Fabricantes.AddRange(new List<Fabricante>
    {
        fabricante1
    });

    Estado estado1 = new Estado
    {
        Name = "DISPONIBLE",
        Description = "descripcion estado 1"
    };
    Estado estado2 = new Estado
    {
        Name = "NO_DISPONIBLE",
        Description = "descripcion estado 2"
    };

    dbContext.Estados.AddRange(new List<Estado>
    {
        estado1,
        estado2
    });

    dbContext.Terminales.AddRange(new List<Terminal> {
        new Terminal
        {
            Name = "terminal test 1",
            Description = "terminal description 1",
            FechaEstado = DateTime.Now,
            FechaFabricacion = DateTime.Now,
            Estado = estado1,
            Fabricante = fabricante1,
        },
        new Terminal
        {
            Name = "terminal test 2",
            Description = "terminal description 2",
            FechaEstado = DateTime.Now,
            FechaFabricacion = DateTime.Now,
            Estado = estado2,
            Fabricante = fabricante1,
        },
        new Terminal
        {
            Name = "terminal test 3",
            Description = "terminal description 3",
            FechaEstado = DateTime.Now,
            FechaFabricacion = DateTime.Now,
            Estado = estado1,
            Fabricante = fabricante1,
        },
    });

    dbContext.SaveChanges();
}

static void ConfigurePipeline(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
}
