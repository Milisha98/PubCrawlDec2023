using ErrorOr;
using MediatR;
using PubCrawl.Core;
using PubCrawl.Core.Errors;
using PubCrawl.Locations.Queries;
using PubCrawl.Locations.Repo;

namespace PubCrawl.Location;

public class LocationValidator : IValidator<LocationDataModel>
{
    private readonly IMediator _mediator;
    public LocationValidator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<List<Error>> ValidateAsync(LocationDataModel location)
    {
        var errors = Validate(location).ToList();
        var list = await _mediator.Send(new ListLocationsQuery());
        if (list?.Any(x => x.LocationName.Trim().ToLower() == location.LocationName?.Trim().ToLower()) ?? false) errors.Add(Errors.Location.Validation.DuplicateLocationName);
        return errors;
    }

    private static IEnumerable<Error> Validate(LocationDataModel Location)
    {
        if (string.IsNullOrWhiteSpace(Location.LocationName)) yield return Errors.Location.Validation.LocationNameRequired;
        if (Location.Sequence < 0) yield return Errors.Location.Validation.SequenceMustBePositive;
    }
}
