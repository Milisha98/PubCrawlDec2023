using MongoDB.Driver;
using PubCrawl.Core.Repo;

namespace PubCrawl.Users.Repo;

public class UserWriteRepo : WriteBase<UserDataModel>
{
    public UserWriteRepo(IMongoDatabase dbConn) : base(dbConn) { }
}		