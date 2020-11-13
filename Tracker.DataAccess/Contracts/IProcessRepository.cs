using Tracker.DataAccess.Entities;

namespace Tracker.DataAccess.Contracts
{
    public interface IProcessRepository
    {
        long Create(Process process);
    }
}
