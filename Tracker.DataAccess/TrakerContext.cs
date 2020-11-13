using Microsoft.EntityFrameworkCore;
using Tracker.DataAccess.Entities;

namespace Tracker.DataAccess
{
    public class TrakerContext : DbContext
    {
        public TrakerContext(DbContextOptions<TrakerContext> options) : base(options) { }

        public DbSet<Document> Documents { get; set; }

        public DbSet<Process> Processes { get; set; }
    }
}
