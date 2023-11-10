using MongoDB.Driver;
using PubCrawl.Core.Repo;

namespace PubCrawl.MessageLogs.Repo;

public class MessageLogReadRepo : ReadBase<MessageLogDataModel>
{
    public MessageLogReadRepo(IMongoDatabase dbConn) : base(dbConn)
    {
    }
}
		