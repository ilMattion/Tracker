using Tracker.Services.Models;

namespace Tracker.Services.Contracts
{
    public interface IDocumentService
    {
        int Create(DocumentDto document);
    }
}
