using Tracker.Models;

namespace Tracker.Services.Models
{
    public class ProcessDto
    {
        public int Identifier { get; set; }

        public ProcessType ProcessType { get; set; }

        public int TimeSpent { get; set; }

        // TODO: Risultato del processo?
    }
}
