using MongoDB.Driver;
using PubCrawlDec2023.Core.Repo;

namespace PubCrawlMarch23.Core.Repo;

public abstract class WriteBase<T> where T: IDataModel
{
	private readonly IMongoDatabase _dbConn;
	private readonly string			_collection;
	public WriteBase(IMongoDatabase dbConn)
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

	public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
	{
        var mongoCollection = _dbConn.GetCollection<T>(_collection);
		var result = await mongoCollection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id), cancellationToken);
		return result.DeletedCount == 1;
    }
}
