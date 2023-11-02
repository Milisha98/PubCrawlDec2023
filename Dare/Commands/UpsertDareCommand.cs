
using ErrorOr;
using MediatR;
using PubCrawl.Core;
using PubCrawl.Dare.Repo;

namespace PubCrawl.Dare.Commands;

public record UpsertDareCommand(string DareID, string DareName, int Score, string Image) : IRequest<ErrorOr<DareDataModel>>;

public class UpsertDareHandler : IRequestHandler<UpsertDareCommand, ErrorOr<DareDataModel>>
{
    public readonly IValidator<DareDataModel> _validator;
    public readonly DareWriteRepo _repo;
    
    public UpsertDareHandler(IValidator<DareDataModel> validator, DareWriteRepo repo)
    {
        _validator = validator;
        _repo = repo;
    }

    public async Task<ErrorOr<DareDataModel>> Handle(UpsertDareCommand request, CancellationToken cancellationToken)
    {
        var dare = new DareDataModel(request.DareID, request.DareName, request.Score, request.Image);

        var validation = _validator.Validate(dare).ToList();
        if (validation.Any()) 
        { 
            return validation;
        }

        await _repo.UpsertAsync(dare, cancellationToken);

        return dare;

    }
}