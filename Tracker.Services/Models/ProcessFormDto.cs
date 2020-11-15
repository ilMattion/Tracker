using Tracker.Models;

namespace Tracker.Services.Models
{
    public class ProcessFormDto
    {
        public ProcessType ProcessType { get; set; }

        public int TimeSpent { get; set; }

        public int DocumentId { get; set; }
    }
}
