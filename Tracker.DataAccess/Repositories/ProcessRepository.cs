using System;
using System.Collections.Generic;
using System.Linq;
using Tracker.DataAccess.Contracts;
using Tracker.DataAccess.Entities;

namespace Tracker.DataAccess.Repositories
{
    public class ProcessRepository : Repository, IProcessRepository
    {
        public ProcessRepository(TrackerContext trackerContext) : base(trackerContext)
        {
        }

        public int Create(Process process)
        {
            process.CreationDate = DateTime.Now.AddMinutes(-59);
            trackerContext.Processes.Add(process);
            trackerContext.SaveChanges();
            return process.Id;
        }

        public IEnumerable<Process> GetByDocumentId(int documentIndentifier)
        {
            return trackerContext.Processes.Where(entity => entity.DocumentId == documentIndentifier);
        }
    }
}
