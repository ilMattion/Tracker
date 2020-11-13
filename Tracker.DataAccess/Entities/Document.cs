using System;
using System.Collections.Generic;
using System.Text;

namespace Tracker.DataAccess.Entities
{
    public class Document
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int Size { get; set; }

        public int UniqueIdentifierReference { get; set; }
    }
}
