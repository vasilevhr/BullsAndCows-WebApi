namespace BullsAndCows.Services.Data.Contracts
{
    using BullsAndCows.Data.Models;
    using System.Linq;

    public interface IHighScoreService
    {
        void UpdateRank(string userId, bool won);

        IQueryable<User> GetLatest();
    }
}
