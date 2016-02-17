namespace BullsAndCows.Web.Wcf
{
    using Data;
    using Data.Models;
    using Data.Repositories;

    public abstract class BaseService
    {
        protected BaseService()
        {
            var db = new BullsAndCowsDbContext();
            this.Users = new GenericRepository<User>(db);
        }

        protected IRepository<User> Users { get; private set; }
    }
}