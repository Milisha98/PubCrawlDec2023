using MongoDB.Driver;
using PubCrawlMarch23.Core.Repo;

namespace PubCrawlDec2023.Dare.Repo;

public class DareWriteRepo : UpsertBase<DareDTO>
{
    public DareWriteRepo(IMongoDatabase dbConn) : base(dbConn) { }
}
