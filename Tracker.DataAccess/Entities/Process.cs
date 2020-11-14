using Tracker.Models;

namespace Tracker.DataAccess.Entities
{
    public class Process
    {
        public int Id { get; set; }

        public ProcessType ProcessType { get; set; }
        
        public int TimeSpent { get; set; }
        
        public int DocumentId { get; set; }
    }
}
