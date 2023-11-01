using MongoDB.Driver;
using PubCrawlDec2023.Core.Repo;

namespace PubCrawlMarch23.Core.Repo;

public abstract class UpsertBase<T> where T: IDTO
{
	private readonly IMongoDatabase _dbConn;
	private readonly string			_collection;
	public UpsertBase(IMongoDatabase dbConn)
	{
		_dbConn		= dbConn;
		_collection = RepoHelper.GetCollection<T>();
	}

	public async Task<T> UpsertAsync(T item, CancellationToken cancellationToken = default)
	{
		var mongoCollection = _dbConn.GetCollection<T>(_collection);
        var options = new ReplaceOptions
        {
            BypassDocumentValidation = false,
			IsUpsert = true
        };
		await mongoCollection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", item.Id), item, options, cancellationToken);
		return item;
	}
}
