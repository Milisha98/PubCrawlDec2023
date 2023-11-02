using MediatR;
using PubCrawl.Locations.Repo;

namespace PubCrawl.Locations.Queries;

public record GetLocationQuery(string LocationID) : IRequest<LocationDataModel?>;

public class GetLocationHandler : IRequestHandler<GetLocationQuery, LocationDataModel?>
{
    private readonly LocationReadRepo _repo;

    public GetLocationHandler(LocationReadRepo repo)
    {
        _repo = repo;
    }

    public Task<LocationDataModel?> Handle(GetLocationQuery request, CancellationToken cancellationToken) =>
        _repo.GetByIDAsync(request.LocationID, cancellationToken);

}
