using Tracker.Models;
using System;

namespace Tracker.Services.Models
{
    public class ProcessDto
    {
        public int Id { get; set; }

        public ProcessType ProcessType { get; set; }

        public int TimeSpent { get; set; }

        public int DocumentId { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
