using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using PubCrawl.Core.Repo;

namespace PubCrawl.Dare.Repo;

public record DareDataModel : IDataModel
{
    // Constructor
    public DareDataModel(string? dareID, string dareName, int score, string image)
    {
        Id = dareID;
        DareName = dareName;
        Score = score;
        Image = image;
    }

    // Properties
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }

    [BsonElement("DareName")]
    public string DareName { get; init; }

    [BsonElement("Score")]
    [BsonRepresentation(BsonType.Int32)]
    public int Score { get; init; }

    [BsonElement("Image")]
    public string Image { get; init; }


}
