using MongoDB.Driver;
using PubCrawl.Core.Repo;

namespace PubCrawl.Scores.Repo;

public class ScoreReadRepo : ReadBase<ScoreDataModel>
{
    public ScoreReadRepo(IMongoDatabase dbConn) : base(dbConn)
    {
    }
}
		