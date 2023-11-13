using MongoDB.Driver;
using PubCrawl.Core.Repo;

namespace PubCrawl.Quiz.Repo;

public class AnswerQuizReadRepo : ReadBase<AnswerQuizDataModel>
{
    public AnswerQuizReadRepo(IMongoDatabase dbConn) : base(dbConn)
    {
    }
}
		