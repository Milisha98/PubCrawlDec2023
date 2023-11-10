using MongoDB.Driver;
using PubCrawl.Core.Repo;

namespace PubCrawl.Quizes.Repo;

public class QuizQuestionReadRepo : ReadBase<QuizQuestionDataModel>
{
    public QuizQuestionReadRepo(IMongoDatabase dbConn) : base(dbConn)
    {
    }
}
		