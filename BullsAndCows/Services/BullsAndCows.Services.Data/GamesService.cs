namespace BullsAndCows.Services.Data
{
    using Contracts;
    using BullsAndCows.Data.Models;
    using BullsAndCows.Data.Repositories;
    using System.Linq;
    using Common.Constants;
    using System;

    public class GamesService : IGamesService
    {
        private IRepository<Game> games;

        public GamesService(IRepository<Game> games)
        {
            this.games = games;
        }

        public IQueryable<Game> GetPublicGames(int page = 1, string userId = null)
        {
            return this.games
                .All()
                .Where(g => g.GameState == GameState.WaitingForOpponent
                    || (g.GameState != GameState.WaitingForOpponent
                    && (g.RedUserId == userId || g.BlueUserId == userId)))
                .OrderBy(g => g.GameState)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedUser.Email)
                .Skip((page - 1) * GameConstants.GamesPerPage)
                .Take(GameConstants.GamesPerPage);
        }

        public Game CreateGame(string name, string number, string userId)
        {
            var newGame = new Game
            {
                Name = name,
                GameState = GameState.WaitingForOpponent,
                RedUserId = userId,
                RedUserNumber = number,
                DateCreated = DateTime.UtcNow
            };

            this.games.Add(newGame);
            this.games.SaveChanges();

            return newGame;
        }

        public IQueryable<Game> GetGameDetails(int id)
        {
            return this.games.All().Where(g => g.Id == id);
        }
    }
}
