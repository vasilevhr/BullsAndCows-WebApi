namespace BullsAndCows.Services.Data.Contracts
{
    using System.Linq;
    using BullsAndCows.Data.Models;

    public interface IGamesService
    {
        IQueryable<Game> GetPublicGames(int page = 0);
    }
}
