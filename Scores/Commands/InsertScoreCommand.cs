using ErrorOr;
using MediatR;
using PubCrawl.Core;
using PubCrawl.Scores.Repo;

namespace PubCrawl.Scores.Commands;

public record InsertScoreCommand(int RoundId, string UserID, int ScoreType, int Points) : IRequest<ErrorOr<ScoreDataModel>>;

public class InsertScoreHandler : IRequestHandler<InsertScoreCommand, ErrorOr<ScoreDataModel>>
{
    public readonly IValidator<ScoreDataModel> _validator;
    public readonly ScoreWriteRepo _repo;

    public InsertScoreHandler(IValidator<ScoreDataModel> validator, ScoreWriteRepo repo)
    {
        _validator = validator;
        _repo 	   = repo;
    }

    public async Task<ErrorOr<ScoreDataModel>> Handle(InsertScoreCommand request, CancellationToken cancellationToken)
    {
        var score = new ScoreDataModel(null, request.RoundId, request.UserID, request.ScoreType, request.Points);
        var validation = await _validator.ValidateAsync(score);
        if (validation.Any())
        {
            return validation;
        }

        score = await _repo.UpsertAsync(score, cancellationToken);

        return score;

    }
}		