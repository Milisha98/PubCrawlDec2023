using MediatR;
using PubCrawlDec2023.Dare.Repo;

namespace PubCrawlDec2023.Dare.Queries;

public record GetDareQuery(string DareID) : IRequest<DareDataModel?>;

public class GetDareHandler : IRequestHandler<GetDareQuery, DareDataModel?>
{
    private readonly DareReadRepo _repo;

    public GetDareHandler(DareReadRepo repo)
    {
        _repo = repo;
    }

    public Task<DareDataModel?> Handle(GetDareQuery request, CancellationToken cancellationToken) =>
        _repo.GetByIDAsync(request.DareID, cancellationToken);

}
