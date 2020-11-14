using System.Collections.Generic;
using Tracker.DataAccess.Entities;

namespace Tracker.DataAccess.Contracts
{
    public interface IProcessRepository
    {
        int Create(Process process);
        IEnumerable<Process> GetByDocumentId(int documentIndentifier);
    }
}
