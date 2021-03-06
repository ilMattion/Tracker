﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using System.Linq;
using Tracker.DataAccess;

namespace Tracker.Integrations
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        public TrackerContext TrackerContext { get; set; }

        public CustomWebApplicationFactory()
        {
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove the app's ApplicationDbContext registration.
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<TrackerContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Add ApplicationDbContext using an in-memory database for testing.

                services.AddDbContext<TrackerContext>(opt => opt.UseSqlite("Filename=test.db"));

                // Build the service provider.
                var sp = services.BuildServiceProvider();
                TrackerContext = sp.GetService<TrackerContext>();
                TrackerContext.Database.EnsureDeleted();
                TrackerContext.Database.EnsureCreated();
            });
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }
    }
}
