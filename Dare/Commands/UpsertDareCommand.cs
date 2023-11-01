
using ErrorOr;
using MediatR;
using PubCrawlDec2023.Core;
using PubCrawlDec2023.Dare.Repo;

namespace PubCrawlDec2023.Dare.Commands;

public record UpsertDareCommand(string DareID, string DareName, int Score, string Image) : IRequest<ErrorOr<DareDTO>>;

public class UpsertDareHandler : IRequestHandler<UpsertDareCommand, ErrorOr<DareDTO>>
{
    public readonly IValidator<DareDTO> _validator;
    public readonly DareWriteRepo _repo;
    
    public UpsertDareHandler(IValidator<DareDTO> validator, DareWriteRepo repo)
    {
        _validator = validator;
        _repo = repo;
    }

    public async Task<ErrorOr<DareDTO>> Handle(UpsertDareCommand request, CancellationToken cancellationToken)
    {
        var dare = new DareDTO(request.DareID, request.DareName, request.Score, request.Image);

        var validation = _validator.Validate(dare).ToList();
        if (validation.Any()) 
        { 
            return validation;
        }

        await _repo.UpsertAsync(dare, cancellationToken);

        return dare;

    }
}