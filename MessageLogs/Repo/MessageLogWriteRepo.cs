using MongoDB.Driver;
using PubCrawl.Core.Repo;

namespace PubCrawl.MessageLogs.Repo;

public class MessageLogWriteRepo : WriteBase<MessageLogDataModel>
{
    public MessageLogWriteRepo(IMongoDatabase dbConn) : base(dbConn) { }
}		