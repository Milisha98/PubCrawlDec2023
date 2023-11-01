using MediatR;
using PubCrawlDec2023.Dare.Repo;

namespace PubCrawlDec2023.Dare.Queries;

public record ListDaresQuery() : IRequest<List<DareDTO>>;

public class ListDaresHandler : IRequestHandler<ListDaresQuery, List<DareDTO>>
{
    private readonly DareReadRepo _repo;

    public ListDaresHandler(DareReadRepo repo)
    {
        _repo = repo;
    }

    public Task<List<DareDTO>> Handle(ListDaresQuery request, CancellationToken cancellationToken) =>
        _repo.ListAsync(cancellationToken);

}
