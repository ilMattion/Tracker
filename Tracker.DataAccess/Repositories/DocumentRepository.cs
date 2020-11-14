using System;
using System.Collections.Generic;
using System.Linq;
using Tracker.DataAccess.Contracts;
using Tracker.DataAccess.Entities;

namespace Tracker.DataAccess.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly TrackerContext trackerContext;

        public DocumentRepository(TrackerContext trakerContext)
        {
            this.trackerContext = trakerContext;
        }

        public int Create(Document document)
        {
            trackerContext.Add(document);
            trackerContext.SaveChanges();
            return document.Id;
        }

        public bool Exists(int documentId)
        {
            return trackerContext.Documents.Any(doc => doc.Id == documentId);
        }

        public IEnumerable<Document> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
