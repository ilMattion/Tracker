using System.Collections.Generic;
using Tracker.Services.Models;

namespace Tracker.Services.Contracts
{
    public interface IDocumentService
    {
        int Create(DocumentFormDto document);
        bool Exists(int documentIndentifier);
        IEnumerable<ProcessDto> GetProcesses(int documentIndentifier);
        int CreateProcess(int documentIdentifier, ProcessFormDto processDto);
        IEnumerable<DocumentDto> Report(string documentCategory);
        IEnumerable<DocumentDto> ReportByLastTimeProcess(int timeProcess);
    }
}
