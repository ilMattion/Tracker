using System;
using System.Collections.Generic;
using System.Text;
using Tracker.DataAccess.Contracts;
using Tracker.DataAccess.Entities;

namespace Tracker.DataAccess.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        public int Create(Document document)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
