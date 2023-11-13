using MongoDB.Driver;
using PubCrawl.Core.Repo;

namespace PubCrawl.Quiz.Repo;

public class AnswerQuizWriteRepo : WriteBase<AnswerQuizDataModel>
{
    public AnswerQuizWriteRepo(IMongoDatabase dbConn) : base(dbConn) { }
}		