using ErrorOr;
using MediatR;
using PubCrawl.Core;
using PubCrawl.Scores.Repo;

namespace PubCrawl.Scores.Commands;

public record UpdateScoreCommand(string ScoreID, int RoundId, string UserID, int ScoreType, int Points) : IRequest<ErrorOr<ScoreDataModel>>;

public class UpdateScoreHandler : IRequestHandler<UpdateScoreCommand, ErrorOr<ScoreDataModel>>
{
    public readonly IValidator<ScoreDataModel> _validator;
    public readonly ScoreWriteRepo _repo;
    
    public UpdateScoreHandler(IValidator<ScoreDataModel> validator, ScoreWriteRepo repo)
    {
        _validator = validator;
        _repo 	   = repo;
    }

    public async Task<ErrorOr<ScoreDataModel>> Handle(UpdateScoreCommand request, CancellationToken cancellationToken)
    {
        var score = new ScoreDataModel(request.ScoreID, request.RoundId, request.UserID, request.ScoreType, request.Points);
        var validation = await _validator.ValidateAsync(score);
        if (validation.Any()) 
        { 
            return validation;
        }

        score = await _repo.UpsertAsync(score, cancellationToken);

        return score;

    }
}