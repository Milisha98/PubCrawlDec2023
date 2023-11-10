using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PubCrawl.Core.Repo;

namespace PubCrawl.Users.Repo;
	
public record UserDataModel : IDataModel
{
	// Constructor
	public UserDataModel(string? id, string code, string name, int pokemon, bool isActive)
	{
	    Id          = id;
		Code = code;
		Name = name;
		Pokemon = pokemon;
		IsActive = isActive;
	}
	
	// Properties
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }
	
	[BsonElement("Code")]
	[BsonRepresentation(BsonType.String)]
	public string Code { get; init; }
	
	[BsonElement("Name")]
	[BsonRepresentation(BsonType.String)]
	public string Name { get; init; }
	
	[BsonElement("Pokemon")]
	[BsonRepresentation(BsonType.Int32)]
	public int Pokemon { get; init; }
	
	[BsonElement("IsActive")]
	[BsonRepresentation(BsonType.Boolean)]
	public bool IsActive { get; init; }
	
}