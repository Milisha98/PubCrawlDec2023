using MediatR;
using PubCrawl.Locations.Repo;

namespace PubCrawl.Locations.Queries;

public record ListLocationsQuery() : IRequest<List<LocationDataModel>>;

public class ListLocationsHandler : IRequestHandler<ListLocationsQuery, List<LocationDataModel>>
{
    private readonly LocationReadRepo _repo;

    public ListLocationsHandler(LocationReadRepo repo)
    {
        _repo = repo;
    }

    public Task<List<LocationDataModel>> Handle(ListLocationsQuery request, CancellationToken cancellationToken) =>
        _repo.ListAsync(cancellationToken);

}
