namespace BullsAndCows.Web.Api.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Models.Games;
    using Services.Data.Contracts;
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;

    public class GamesController : ApiController
    {
        private IGamesService games;

        public GamesController(IGamesService games)
        {
            this.games = games; 
        }

        public IHttpActionResult Get(int page = 1)
        {
            var userId = this.User.Identity.GetUserId();
            var games = this.games
                .GetPublicGames(page)
                .ProjectTo<ListedGameResponseModel>()
                .ToList();

            return this.Ok(games);
        }
    }
}