using System;

namespace BullsAndCows.Web.Api.Models.Games
{
    public class ListedGameResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Red { get; set; }

        public string Blue { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; set; }
    }
}