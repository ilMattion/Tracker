using System.Collections.Generic;
using Tracker.DataAccess.Entities;

namespace Tracker.DataAccess.Contracts
{
    public interface IProcessRepository
    {
        long Create(Process process);
        IEnumerable<Process> GetByDocumentId(int documentIndentifier);
    }
}
