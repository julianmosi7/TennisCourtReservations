using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace TennisCourtReservationsDb
{
    public static class MigrationManagerExtension
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using var db = scope.ServiceProvider.GetRequiredService<TennisContext>();
                try
                {
                    Console.WriteLine("Completely remove database file...");
                    db.Database.EnsureDeleted();
                    Console.WriteLine("db.Database.Migrate()...");
                    db.Database.Migrate();
                    Console.WriteLine($"Datasource: {db.Database.GetDbConnection().DataSource}");
                    int nr = db.Persons.Count();
                    Console.WriteLine($"nr Persons: {nr}");
                }catch (Exception exc)
                {
                    Console.WriteLine($"*** Could not migrate database - Reason {exc.Message}");
                    throw;
                }
            }
            return host;
        }
    }
}
