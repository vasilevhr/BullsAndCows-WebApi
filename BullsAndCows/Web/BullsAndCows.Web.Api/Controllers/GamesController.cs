namespace BullsAndCows.Web.Api.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Models.Games;
    using Services.Data.Contracts;
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using AutoMapper;
    using Infrastructure.Validation;

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
        [ValidateModel]
        public IHttpActionResult Post(CreateGameRequestModel model)
        {
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

        [Authorize]
        [ValidateModel]
        public IHttpActionResult Put(int id, BaseGameRequestModel model) 
        {
            var userId = this.User.Identity.GetUserId();
            if (!this.games.GameCanBeJoinedByUser(id, userId))
            {
                return this.BadRequest("This game is yours!");
            }

            //TODO: add notification

            var joinedGame = this.games.JoinGame(id, model.Number, userId);

            return this.Ok(new { result = string.Format("You joined game \"{0}\"", joinedGame) });
        }
    }
}