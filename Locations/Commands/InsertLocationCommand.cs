using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PubCrawl.Core;
using PubCrawl.Locations.Queries;
using PubCrawl.Locations.Repo;

namespace PubCrawl.Locations.Commands;

public record InsertLocationCommand(string Name) : IRequest<ErrorOr<LocationDataModel>>;

public class InsertLocationHandler : IRequestHandler<InsertLocationCommand, ErrorOr<LocationDataModel>>
{
    public readonly IMediator _mediator;
    public readonly IValidator<LocationDataModel> _validator;
    public readonly LocationWriteRepo _repo;

    public InsertLocationHandler(IMediator mediator, IValidator<LocationDataModel> validator, LocationWriteRepo repo)
    {
        _mediator = mediator;
        _validator = validator;
        _repo = repo;
    }

    public async Task<ErrorOr<LocationDataModel>> Handle(InsertLocationCommand request, CancellationToken cancellationToken)
    {
        // Default Values
        int sequence = await GetNextSequence(cancellationToken);

        // Validate
        var location = new LocationDataModel(null, sequence, request.Name, true);
        var validation = await _validator.ValidateAsync(location, true);
        if (validation.Any())
        {
            return validation;
        }

        // Insert
        location = await _repo.UpsertAsync(location, cancellationToken);

        return location;

    }

    private async Task<int> GetNextSequence(CancellationToken cancellationToken)
    {
        var listQuery = new ListLocationsQuery();
        var list = await _mediator.Send(listQuery, cancellationToken);
        int sequence = list is null ? 0 : list.Max(x => x.Sequence) + 1;
        return sequence;
    }
}