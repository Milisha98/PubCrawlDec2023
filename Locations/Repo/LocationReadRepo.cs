using MongoDB.Driver;
using PubCrawl.Core.Repo;

namespace PubCrawl.Locations.Repo;

public class LocationReadRepo : ReadBase<LocationDataModel>
{
    public LocationReadRepo(IMongoDatabase dbConn) : base(dbConn)
    {
    }
}
