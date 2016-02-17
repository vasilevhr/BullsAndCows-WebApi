namespace BullsAndCows.Web.Api.Models.Guesses
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class GuessDetailsResponseModel : IMapFrom<Guess>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public int GameId { get; set; }

        public string  Number { get; set; }

        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            Mapper.CreateMap<Guess, GuessDetailsResponseModel>()
                .ForMember(g => g.Username, opts => opts.MapFrom(g => g.User.Email));
        }
    }
}