namespace BullsAndCows.Web.Api.Controllers
{
    using Services.Data.Contracts;
    using System.Web.Http;


    public class GamesController : ApiController
    {
        private IGamesService games;

        public GamesController(IGamesService games)
        {
            this.games = games; 
        }

        public IHttpActionResult Get(int page = 1)
        {
            return null;
        }
    }
}