using MediatR;
using PubCrawlDec2023.Dare.Repo;

namespace PubCrawlDec2023.Dare.Queries;

public record ListDaresQuery() : IRequest<List<DareDataModel>>;

public class ListDaresHandler : IRequestHandler<ListDaresQuery, List<DareDataModel>>
{
    private readonly DareReadRepo _repo;

    public ListDaresHandler(DareReadRepo repo)
    {
        _repo = repo;
    }

    public Task<List<DareDataModel>> Handle(ListDaresQuery request, CancellationToken cancellationToken) =>
        _repo.ListAsync(cancellationToken);

}
