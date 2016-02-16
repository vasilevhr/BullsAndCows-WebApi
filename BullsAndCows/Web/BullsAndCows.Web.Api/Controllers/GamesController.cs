namespace BullsAndCows.Web.Api.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Models.Games;
    using Services.Data.Contracts;
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using AutoMapper;

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

        [Authorize]
        public IHttpActionResult Post(CreateGameRequestModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                if (model == null)
                {
                    return this.BadRequest("Game cannot be empty!"); 
                }
                return this.BadRequest(this.ModelState);
            }

            var newGame = this.games.CreateGame(
                model.Name,
                model.Number,
                this.User.Identity.GetUserId());

            var gameResult = games
                    .GetGameDetails(newGame.Id)
                    .ProjectTo<ListedGameResponseModel>()
                    .FirstOrDefault();

            return this.Created(
                string.Format("/api/Games/{0}", newGame.Id),
                gameResult);
        }
    }
}