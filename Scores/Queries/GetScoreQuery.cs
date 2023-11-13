using MediatR;
using PubCrawl.Scores.Repo;

namespace PubCrawl.Scores.Queries;

public record GetScoreQuery(string ScoreID) : IRequest<ScoreDataModel?>;

public class GetScoreHandler : IRequestHandler<GetScoreQuery, ScoreDataModel?>
{
    private readonly ScoreReadRepo _repo;

    public GetScoreHandler(ScoreReadRepo repo)
    {
        _repo = repo;
    }

    public Task<ScoreDataModel?> Handle(GetScoreQuery request, CancellationToken cancellationToken) =>
        _repo.GetByIDAsync(request.ScoreID, cancellationToken);

}		