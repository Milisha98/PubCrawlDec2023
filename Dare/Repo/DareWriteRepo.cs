using MongoDB.Driver;
using PubCrawlMarch23.Core.Repo;

namespace PubCrawlDec2023.Dare.Repo;

public class DareWriteRepo : WriteBase<DareDataModel>
{
    public DareWriteRepo(IMongoDatabase dbConn) : base(dbConn) { }
}
