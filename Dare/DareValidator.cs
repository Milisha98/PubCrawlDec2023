using ErrorOr;
using MediatR;
using PubCrawl.Core;
using PubCrawl.Core.Errors;
using PubCrawl.Dare.Queries;
using PubCrawl.Dare.Repo;

namespace PubCrawl.Dare;

public class DareValidator : IValidator<DareDataModel>
{
    private readonly IMediator _mediator;
    public DareValidator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<List<Error>> ValidateAsync(DareDataModel dare)
    {
        var errors = Validate(dare).ToList();
        var list = await _mediator.Send(new ListDaresQuery());
        if (list?.Any(x => x.DareName.Trim().ToLower() == dare.DareName?.Trim().ToLower()) ?? false) errors.Add(Errors.Dare.Validation.DuplicateDareName);

        return errors;

    }

    private static IEnumerable<Error> Validate(DareDataModel dare) 
    {
        if (string.IsNullOrWhiteSpace(dare.DareName)) yield return Errors.Dare.Validation.DareNameRequired;
        if (dare.Score < 1) yield return Errors.Dare.Validation.ScoreMustBePositive;
    }


}
