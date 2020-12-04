using Microsoft.EntityFrameworkCore;
using System;
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

        public IEnumerable<Document> ReportByLastTimeProcess(int timeProcess)
        {
            return (from document in trackerContext.Documents
                    join process in trackerContext.Processes
                    on document.Id equals process.DocumentId
                    where DateTime.Now.AddHours(timeProcess * -1) <= process.CreationDate
                    select new Document()
                    {
                        Category = document.Category,
                        Id = document.Id,
                        Name = document.Name,
                        Processes = document.Processes,
                        Size = document.Size,
                        UniqueIdentifierReference = document.UniqueIdentifierReference
                    }).Distinct();
        }
    }
}
