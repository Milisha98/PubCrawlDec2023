using ErrorOr;
using PubCrawlDec2023.Core;
using PubCrawlDec2023.Core.Errors;
using PubCrawlDec2023.Dare.Repo;

namespace PubCrawlDec2023.Dare;

public class DareValidator : IValidator<DareDTO>
{
    public IEnumerable<Error> Validate(DareDTO dare)
    {
        if (string.IsNullOrWhiteSpace(dare.DareName)) yield return Errors.Dare.Validation.DareNameRequired;
        if (string.IsNullOrWhiteSpace(dare.Image)) yield return Errors.Dare.Validation.ImageRequired;
        if (dare.Score < 1) yield return Errors.Dare.Validation.ScoreMustBePositive;
    }
}
