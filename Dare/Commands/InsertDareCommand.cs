using ErrorOr;
using MediatR;
using PubCrawl.Core;
using PubCrawl.Dare.Repo;

namespace PubCrawl.Dare.Commands;

public record InsertDareCommand(string DareName, int Score, string Image) : IRequest<ErrorOr<DareDataModel>>;

public class InsertDareHandler : IRequestHandler<InsertDareCommand, ErrorOr<DareDataModel>>
{
    public readonly IValidator<DareDataModel> _validator;
    public readonly DareWriteRepo _repo;

    public InsertDareHandler(IValidator<DareDataModel> validator, DareWriteRepo repo)
    {
        _validator = validator;
        _repo = repo;
    }

    public async Task<ErrorOr<DareDataModel>> Handle(InsertDareCommand request, CancellationToken cancellationToken)
    {
        var dare = new DareDataModel(null, request.DareName, request.Score, request.Image);
        var validation = await _validator.ValidateAsync(dare, true);
        if (validation.Any())
        {
            return validation;
        }

        dare = await _repo.UpsertAsync(dare, cancellationToken);

        return dare;

    }
}
