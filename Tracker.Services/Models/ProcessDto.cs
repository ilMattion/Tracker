using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Tracker.Models;

namespace Tracker.Services.Models
{
    public class ProcessDto
    {
        public int Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ProcessType ProcessType { get; set; }

        public int TimeSpent { get; set; }

        public int DocumentId { get; set; }
    }
}
