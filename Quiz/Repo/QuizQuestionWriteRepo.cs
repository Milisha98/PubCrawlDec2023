using MongoDB.Driver;
using PubCrawl.Core.Repo;

namespace PubCrawl.Quizes.Repo;

public class QuizQuestionWriteRepo : WriteBase<QuizQuestionDataModel>
{
    public QuizQuestionWriteRepo(IMongoDatabase dbConn) : base(dbConn) { }
}		