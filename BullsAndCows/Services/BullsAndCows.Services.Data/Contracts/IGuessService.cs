namespace BullsAndCows.Services.Data.Contracts
{
    using BullsAndCows.Data.Models;
    using System.Linq;

    public interface IGuessService
    {
        Guess MakeGuess(int gameId, string number, string userId);

        IQueryable<Guess> GetGuessDetails(int id);
    }
}
