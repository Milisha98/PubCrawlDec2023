using ErrorOr;
using PubCrawl.Core;
using PubCrawl.Core.Errors;
using PubCrawl.Dare.Repo;

namespace PubCrawl.Dare;

public class DareValidator : IValidator<DareDataModel>
{
    public IEnumerable<Error> Validate(DareDataModel dare)
    {
        if (string.IsNullOrWhiteSpace(dare.DareName)) yield return Errors.Dare.Validation.DareNameRequired;
        if (string.IsNullOrWhiteSpace(dare.Image)) yield return Errors.Dare.Validation.ImageRequired;
        if (dare.Score < 1) yield return Errors.Dare.Validation.ScoreMustBePositive;
    }
}
