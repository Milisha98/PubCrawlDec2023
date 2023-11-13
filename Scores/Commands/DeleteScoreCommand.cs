using MediatR;
using PubCrawl.Scores.Repo;

namespace PubCrawl.Scores.Commands;

public record DeleteScoreCommand(string ScoreID) : IRequest<bool>;

public class DeleteScoreHandler : IRequestHandler<DeleteScoreCommand, bool>
{
    public readonly ScoreWriteRepo _repo;

    public DeleteScoreHandler(ScoreWriteRepo repo)
    {
        _repo = repo;
    }

    public Task<bool> Handle(DeleteScoreCommand request, CancellationToken cancellationToken) =>
        _repo.DeleteAsync(request.ScoreID, cancellationToken);
}		