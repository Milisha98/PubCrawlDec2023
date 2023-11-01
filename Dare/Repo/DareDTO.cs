using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;
using PubCrawlDec2023.Core.Repo;

namespace PubCrawlDec2023.Dare.Repo;

public record DareDTO : IDTO
{
    // Constructor
    public DareDTO(string dareID, string dareName, int score, string image)
    {
        Id = dareID;
        DareName = dareName;
        Score = score;
        Image = image;
    }

    // Properties
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonElement("_id")]
    public string Id { get; init; }

    [BsonElement("DareName")]
    public string DareName { get; init; }

    [BsonElement("Score")]
    [BsonRepresentation(BsonType.Int32)]
    public int Score { get; init; }

    [BsonElement("Image")]
    public string Image { get; init; }


}
