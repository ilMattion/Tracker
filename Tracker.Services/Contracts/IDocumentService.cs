using System.Collections.Generic;
using Tracker.Services.Models;

namespace Tracker.Services.Contracts
{
    public interface IDocumentService
    {
        int Create(DocumentDto document);
        bool Exists(int documentIndentifier);
        IEnumerable<ProcessDto> GetProcesses(int documentIndentifier);
        int CreateProcess(int documentIdentifier, ProcessDto processDto);
        IEnumerable<DocumentDto> Report();
    }
}
