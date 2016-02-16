namespace BullsAndCows.Web.Api.Models.Games
{
    using BullsAndCows.Common.Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class CreateGameRequestModel : IValidatableObject
    {
        [Required]
        [MaxLength(GameConstants.GameNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(GameConstants.GuessNumberLength)]
        [MaxLength(GameConstants.GuessNumberLength)]
        public string Number { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var digits = this.Number.Distinct().ToList();

            if (digits.Count != GameConstants.GuessNumberLength)
            {
                yield return new ValidationResult("Number's digits must be distinct!");
            }
        }
    }
}