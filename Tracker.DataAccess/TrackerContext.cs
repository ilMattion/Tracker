using Microsoft.EntityFrameworkCore;
using Tracker.DataAccess.Entities;

namespace Tracker.DataAccess
{
    public class TrackerContext : DbContext
    {
        public TrackerContext(DbContextOptions<TrackerContext> options) : base(options) { }

        public DbSet<Document> Documents { get; set; }

        public DbSet<Process> Processes { get; set; }
    }
}
