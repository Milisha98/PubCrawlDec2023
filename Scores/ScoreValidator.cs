using ErrorOr;
using MediatR;
using PubCrawl.Core.Errors;
using PubCrawl.Scores.Queries;
using PubCrawl.Scores.Repo;

namespace PubCrawl.Scores;

public class ScoreValidator
{
    private readonly IMediator _mediator;
    public ScoreValidator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<List<Error>> ValidateAsync(ScoreDataModel score)
    {
        var errors = Validate(score).ToList();
		var list = await _mediator.Send(new ListScoresQuery());
		if (list.Any(x => ( score.Id != x.Id ) && 
			 			  ( ( x.RoundId == score.RoundId ) )))
		{
			errors.Add(Errors.Score.Validation.DuplicateScore);
		}
        return errors;

    }

    private static IEnumerable<Error> Validate(ScoreDataModel score) 
    {
		// Mandatory Validation
        
		
		throw new NotImplementedException();
    }


}		