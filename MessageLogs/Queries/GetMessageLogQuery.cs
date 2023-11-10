using MediatR;
using PubCrawl.MessageLogs.Repo;

namespace PubCrawl.MessageLogs.Queries;

public record GetMessageLogQuery(string MessageLogID) : IRequest<MessageLogDataModel?>;

public class GetMessageLogHandler : IRequestHandler<GetMessageLogQuery, MessageLogDataModel?>
{
    private readonly MessageLogReadRepo _repo;

    public GetMessageLogHandler(MessageLogReadRepo repo)
    {
        _repo = repo;
    }

    public Task<MessageLogDataModel?> Handle(GetMessageLogQuery request, CancellationToken cancellationToken) =>
        _repo.GetByIDAsync(request.MessageLogID, cancellationToken);

}		