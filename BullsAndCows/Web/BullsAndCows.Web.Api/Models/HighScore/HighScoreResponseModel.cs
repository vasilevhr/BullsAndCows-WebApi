namespace BullsAndCows.Web.Api.Models.HighScore
{
    using Data.Models;
    using Infrastructure.Mappings;
    using System;
    using AutoMapper;

    public class HighScoreResponseModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Username { get; set; }

        public int Rank { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            Mapper.CreateMap<User, HighScoreResponseModel>()
                .ForMember(u => u.Username, opts => opts.MapFrom(u => u.Email));
        }
    }
}