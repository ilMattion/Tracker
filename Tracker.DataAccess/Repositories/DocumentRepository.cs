using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tracker.DataAccess.Contracts;
using Tracker.DataAccess.Entities;

namespace Tracker.DataAccess.Repositories
{
    public class DocumentRepository : Repository, IDocumentRepository
    {
        public DocumentRepository(TrackerContext trackerContext) : base(trackerContext)
        {
        }


        public bool Exists(int documentId)
        {
            return trackerContext.Documents.Any(doc => doc.Id == documentId);
        }
        
        public Document GetById(int documentIdentifier)
        {
            return trackerContext.Documents.FirstOrDefault(entity => entity.Id == documentIdentifier);
        }

        public int Create(Document document)
        {
            trackerContext.Add(document);
            trackerContext.SaveChanges();
            return document.Id;
        }

        public IEnumerable<Document> Report(string documentCategory)
        {
            return trackerContext.Documents.Where(x => x.Category == documentCategory).Include(entity => entity.Processes).ToList();
        }
    }
}
