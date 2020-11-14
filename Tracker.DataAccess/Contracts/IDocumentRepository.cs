using System.Collections.Generic;
using Tracker.DataAccess.Entities;

namespace Tracker.DataAccess.Contracts
{
    public interface IDocumentRepository
    {
        IEnumerable<Document> Report();
        int Create(Document document);
        bool Exists(int documentId);
    }
}
