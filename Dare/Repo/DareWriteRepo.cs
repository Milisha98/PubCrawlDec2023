using MongoDB.Driver;
using PubCrawlMarch23.Core.Repo;

namespace PubCrawlDec2023.Dare.Repo;

public class DareWriteRepo : WriteBase<DareDTO>
{
    public DareWriteRepo(IMongoDatabase dbConn) : base(dbConn) { }
}
