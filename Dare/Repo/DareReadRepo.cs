using MongoDB.Driver;
using PubCrawl.Core.Repo;

namespace PubCrawl.Dare.Repo;

public class DareReadRepo : ReadBase<DareDataModel>
{
    public DareReadRepo(IMongoDatabase dbConn) : base(dbConn)
    {
    }
}
