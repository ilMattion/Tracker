namespace Tracker.DataAccess.Repositories
{
    public abstract class Repository
    {
        protected readonly TrackerContext trackerContext;

        public Repository(TrackerContext trackerContext)
        {
            this.trackerContext = trackerContext;
        }
    }
}
