using MediatR;
using PubCrawl.Scores.Repo;

namespace PubCrawl.Scores.Queries;

public record ListScoresQuery() : IRequest<List<ScoreDataModel>>;

public class ListScoresHandler : IRequestHandler<ListScoresQuery, List<ScoreDataModel>>
{
    private readonly ScoreReadRepo _repo;

    public ListScoresHandler(ScoreReadRepo repo)
    {
        _repo = repo;
    }

    public Task<List<ScoreDataModel>> Handle(ListScoresQuery request, CancellationToken cancellationToken) =>
        _repo.ListAsync(cancellationToken);

}		