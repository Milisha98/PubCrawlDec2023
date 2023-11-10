using MediatR;
using PubCrawl.MessageLogs.Repo;

namespace PubCrawl.MessageLogs.Queries;

public record ListMessageLogsQuery() : IRequest<List<MessageLogDataModel>>;

public class ListMessageLogsHandler : IRequestHandler<ListMessageLogsQuery, List<MessageLogDataModel>>
{
    private readonly MessageLogReadRepo _repo;

    public ListMessageLogsHandler(MessageLogReadRepo repo)
    {
        _repo = repo;
    }

    public Task<List<MessageLogDataModel>> Handle(ListMessageLogsQuery request, CancellationToken cancellationToken) =>
        _repo.ListAsync(cancellationToken);

}		