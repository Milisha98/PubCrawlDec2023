using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PubCrawl.Core.Repo;

namespace PubCrawl.Scores.Repo;
	
public record ScoreDataModel : IDataModel
{
	// Constructor
	public ScoreDataModel(string? id, int roundId, string userID, int scoreType, int points)
	{
	    Id          = id;
		RoundId = roundId;
		UserID = userID;
		ScoreType = scoreType;
		Points = points;
	}
	
	// Properties
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }
	
	[BsonElement("RoundId")]
	[BsonRepresentation(BsonType.Int32)]
	public int RoundId { get; init; }
	
	[BsonElement("UserID")]
	[BsonRepresentation(BsonType.String)]
	public string UserID { get; init; }
	
	[BsonElement("ScoreType")]
	[BsonRepresentation(BsonType.Int32)]
	public int ScoreType { get; init; }
	
	[BsonElement("Points")]
	[BsonRepresentation(BsonType.Int32)]
	public int Points { get; init; }
	
}