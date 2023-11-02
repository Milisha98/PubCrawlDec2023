using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using PubCrawl.Core.Repo;

namespace PubCrawl.Locations.Repo;

public record LocationDataModel : IDataModel
{
    public LocationDataModel(string? id, int sequence, string name, bool isActive)
    {
        Id              = id;
        Sequence        = sequence;
        LocationName    = name;
        IsActive        = isActive;
    }

    // Properties
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }

    [BsonElement("Sequence")]
    [BsonRepresentation(BsonType.Int32)]
    public int Sequence { get; init; }

    [BsonElement("LocationName")]
    public string LocationName { get; init; }

    [BsonElement("IsActive")]
    [BsonRepresentation(BsonType.Boolean)]
    public bool IsActive { get; init; }

}
