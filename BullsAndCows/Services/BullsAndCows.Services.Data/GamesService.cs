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

        public IQueryable<Game> GetPublicGames(int page = 0)
        {
            return this.games
                .All()
                .Where(g => g.GameState == GameState.WaitingForOpponent)
                .OrderBy(g => g.GameState)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedUser.Email);
        }
    }
}
