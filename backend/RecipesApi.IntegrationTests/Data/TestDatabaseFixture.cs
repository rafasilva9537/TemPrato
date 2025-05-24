using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RecipesApi.Data;

namespace RecipesApi.IntegrationTests.Data;

public class TestDatabaseFixture : IDisposable
{
    private readonly static object _lock = new();
    private static bool _databaseIsInitialized = false;

    public TestDatabaseFixture()
    {
        lock (_lock)
        {
            if (!_databaseIsInitialized)
            {
                InitializeDatabase();
                _databaseIsInitialized = true;
            }
        }
    }

    public void InitializeDatabase()
    {
        using var context = GetDbContext();
        context.Database.EnsureDeleted(); // TODO: remove when data seed is implemented
        context.Database.EnsureCreated();
    }

    public AppDbContext GetDbContext()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

        var connectionString = configuration.GetConnectionString("DBTestConnection");

        var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        var context = new AppDbContext(dbContextOptions);

        return context;
    }

    public void Dispose()
    {
        using var context = GetDbContext();
        // TODO: put db removing here
    }
}
