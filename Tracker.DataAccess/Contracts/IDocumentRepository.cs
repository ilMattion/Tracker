using System.Collections.Generic;
using Tracker.DataAccess.Entities;

namespace Tracker.DataAccess.Contracts
{
    public interface IDocumentRepository
    {
        IEnumerable<Document> Report(string documentCategory);
        IEnumerable<Document> ReportByLastTimeProcess(int timeProcess);
        int Create(Document document);
        bool Exists(int documentId);
        Document GetById(int documentIdentifier);
    }
}
