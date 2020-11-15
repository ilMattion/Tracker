using System.Collections.Generic;

namespace Tracker.Services.Models
{
    public class DocumentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int Size { get; set; }

        public string UniqueIdentifierReference { get; set; }

        public IList<ProcessDto> Processes { get; set; }
    }
}
