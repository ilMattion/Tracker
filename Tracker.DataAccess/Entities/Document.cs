using System.Collections.Generic;

namespace Tracker.DataAccess.Entities
{
    public class Document
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int Size { get; set; }

        public string UniqueIdentifierReference { get; set; }

        public List<Process> Processes { get; set; }
    }
}
