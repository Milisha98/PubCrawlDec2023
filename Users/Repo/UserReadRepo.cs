using MongoDB.Driver;
using PubCrawl.Core.Repo;

namespace PubCrawl.Users.Repo;

public class UserReadRepo : ReadBase<UserDataModel>
{
    public UserReadRepo(IMongoDatabase dbConn) : base(dbConn)
    {
    }
}
		