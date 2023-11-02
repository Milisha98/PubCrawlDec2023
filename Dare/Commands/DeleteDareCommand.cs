using MediatR;
using PubCrawl.Dare.Repo;

namespace PubCrawl.Dare.Commands;

public record DeleteDareCommand(string DareId) : IRequest<bool>;

public class DeleteDareHandler : IRequestHandler<DeleteDareCommand, bool>
{
    public readonly DareWriteRepo _repo;

    public DeleteDareHandler(DareWriteRepo repo)
    {
        _repo = repo;
    }

    public Task<bool> Handle(DeleteDareCommand request, CancellationToken cancellationToken) =>
        _repo.DeleteAsync(request.DareId, cancellationToken);
}
