using MediatR;
using PubCrawlDec2023.Dare.Repo;

namespace PubCrawlDec2023.Dare.Queries;

public record GetDareQuery(string DareID) : IRequest<DareDTO?>;

public class GetDareHandler : IRequestHandler<GetDareQuery, DareDTO?>
{
    private readonly DareReadRepo _repo;

    public GetDareHandler(DareReadRepo repo)
    {
        _repo = repo;
    }

    public Task<DareDTO?> Handle(GetDareQuery request, CancellationToken cancellationToken) =>
        _repo.GetByIDAsync(request.DareID, cancellationToken);

}
