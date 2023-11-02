using MongoDB.Driver;
using PubCrawl.Core.Repo;

namespace PubCrawlMarch23.Core.Repo;

public class ReadBase<T>
{
    private readonly IMongoDatabase _dbConn;
    private readonly string         _collection;
    public ReadBase(IMongoDatabase dbConn)
    {
        _dbConn     = dbConn;
        _collection = RepoHelper.GetCollection<T>();
    }

    public async Task<T?> GetByIDAsync(string id, CancellationToken cancellationToken = default)
    {
        var collection = _dbConn.GetCollection<T>(_collection);
        return await collection.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
    {
        var collection = _dbConn.GetCollection<T>(_collection);
        var results = await collection.FindAsync<T>(_ => true, null, cancellationToken);
        return results.ToList();
    }
}
