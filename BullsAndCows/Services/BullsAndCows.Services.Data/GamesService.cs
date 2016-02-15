namespace BullsAndCows.Services.Data
{
    using Contracts;
    using BullsAndCows.Data.Models;
    using BullsAndCows.Data.Repositories;
    using System.Linq;

    public class GamesService : IGamesService
    {
        private IRepository<Game> games;

        public GamesService(IRepository<Game> games)
        {
            this.games = games;
        }

        public IQueryable<Game> GetGames(int page = 0)
        {
            return null;
        }
    }
}
