using MediatR;
using PubCrawl.MessageLogs.Repo;

namespace PubCrawl.MessageLogs.Commands;

public record DeleteMessageLogCommand(string MessageLogID) : IRequest<bool>;

public class DeleteMessageLogHandler : IRequestHandler<DeleteMessageLogCommand, bool>
{
    public readonly MessageLogWriteRepo _repo;

    public DeleteMessageLogHandler(MessageLogWriteRepo repo)
    {
        _repo = repo;
    }

    public Task<bool> Handle(DeleteMessageLogCommand request, CancellationToken cancellationToken) =>
        _repo.DeleteAsync(request.MessageLogID, cancellationToken);
}		