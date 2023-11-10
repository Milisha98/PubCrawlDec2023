
using ErrorOr;
using MediatR;
using PubCrawl.Core;
using PubCrawl.Locations.Repo;

namespace PubCrawl.Locations.Commands;

public record UpdateLocationCommand(string? LocationID, int Sequence, string Name, bool IsActive) : IRequest<ErrorOr<LocationDataModel>>;

public class UpdateLocationHandler : IRequestHandler<UpdateLocationCommand, ErrorOr<LocationDataModel>>
{
    public readonly IValidator<LocationDataModel> _validator;
    public readonly LocationWriteRepo _repo;
    
    public UpdateLocationHandler(IValidator<LocationDataModel> validator, LocationWriteRepo repo)
    {
        _validator = validator;
        _repo = repo;
    }

    public async Task<ErrorOr<LocationDataModel>> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var Location = new LocationDataModel(request.LocationID, request.Sequence, request.Name, request.IsActive);

        var validation = await _validator.ValidateAsync(Location);
        if (validation.Any()) 
        { 
            return validation;
        }

        await _repo.UpsertAsync(Location, cancellationToken);

        return Location;

    }
}