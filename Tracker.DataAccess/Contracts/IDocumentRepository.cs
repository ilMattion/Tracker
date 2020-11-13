using System.Collections.Generic;
using Tracker.DataAccess.Entities;

namespace Tracker.DataAccess.Contracts
{
    public interface IDocumentRepository
    {
        IEnumerable<Document> GetAll();

        int Create(Document document);
    }
}
