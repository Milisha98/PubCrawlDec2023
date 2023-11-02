using MongoDB.Driver;
using PubCrawlMarch23.Core.Repo;

namespace PubCrawlDec2023.Dare.Repo;

public class DareReadRepo : ReadBase<DareDataModel>
{
    public DareReadRepo(IMongoDatabase dbConn) : base(dbConn)
    {
    }
}
