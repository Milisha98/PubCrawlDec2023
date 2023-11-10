using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PubCrawl.Core.Repo;

namespace PubCrawl.MessageLogs.Repo;
	
public record MessageLogDataModel : IDataModel
{
	// Constructor
	public MessageLogDataModel(string? id, DateTime when, string message)
	{
	    Id          = id;
		When = when;
		Message = message;
	}
	
	// Properties
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }
	
	[BsonElement("When")]
	[BsonRepresentation(BsonType.DateTime)]
	public DateTime When { get; init; }
	
	[BsonElement("Message")]
	[BsonRepresentation(BsonType.String)]
	public string Message { get; init; }
	
}