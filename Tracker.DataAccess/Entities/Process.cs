using Tracker.Models;

namespace Tracker.DataAccess.Entities
{
    public class Process
    {
        public int Identifier { get; set; }

        public ProcessType ProcessType { get; set; }

        public int TimeSpent { get; set; }
    }
}
