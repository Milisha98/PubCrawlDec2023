using MongoDB.Driver;
using PubCrawl.Core.Repo;

namespace PubCrawl.Locations.Repo;

public class LocationWriteRepo : WriteBase<LocationDataModel>
{
    public LocationWriteRepo(IMongoDatabase dbConn) : base(dbConn) { }
}
