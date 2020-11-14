using Tracker.Models;

namespace Tracker.Services.Models
{
    public class ProcessDto
    {
        public int Id { get; set; }

        public ProcessType ProcessType { get; set; }

        public int TimeSpent { get; set; }

        public int DocumentId { get; set; }
    }
}
