
using ErrorOr;
using MediatR;
using PubCrawl.Core;
using PubCrawl.Dare.Repo;

namespace PubCrawl.Dare.Commands;

public record UpdateDareCommand(string DareID, string DareName, int Score, string Image) : IRequest<ErrorOr<DareDataModel>>;

public class UpdateDareHandler : IRequestHandler<UpdateDareCommand, ErrorOr<DareDataModel>>
{
    public readonly IValidator<DareDataModel> _validator;
    public readonly DareWriteRepo _repo;
    
    public UpdateDareHandler(IValidator<DareDataModel> validator, DareWriteRepo repo)
    {
        _validator = validator;
        _repo = repo;
    }

    public async Task<ErrorOr<DareDataModel>> Handle(UpdateDareCommand request, CancellationToken cancellationToken)
    {
        var dare = new DareDataModel(request.DareID, request.DareName, request.Score, request.Image);
        var validation = await _validator.ValidateAsync(dare, false);
        if (validation.Any()) 
        { 
            return validation;
        }

        dare = await _repo.UpsertAsync(dare, cancellationToken);

        return dare;

    }
}