namespace BullsAndCows.Services.Data.Contracts
{
    using System.Linq;
    using BullsAndCows.Data.Models;

    public interface IGamesService
    {
        IQueryable<Game> GetPublicGames(int page = 0, string userId = null);
        Game CreateGame(string name, string number, string userId);
        IQueryable<Game> GetGameDetails(int id);
    }
}
