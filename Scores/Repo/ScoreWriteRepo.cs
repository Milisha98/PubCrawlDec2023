using MongoDB.Driver;
using PubCrawl.Core.Repo;

namespace PubCrawl.Scores.Repo;

public class ScoreWriteRepo : WriteBase<ScoreDataModel>
{
    public ScoreWriteRepo(IMongoDatabase dbConn) : base(dbConn) { }
}		