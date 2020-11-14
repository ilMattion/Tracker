using System;
using System.Collections.Generic;
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

        public IEnumerable<Document> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
