using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PubCrawl.Core.Repo;

namespace PubCrawl.Quizes.Repo;
	
public record QuizQuestionDataModel : IDataModel
{
	// Constructor
	public QuizQuestionDataModel(string? id, string question, string answer1, string answer2, string answer3, string answer4, int answer)
	{
	    Id          = id;
		Question = question;
		Answer1 = answer1;
		Answer2 = answer2;
		Answer3 = answer3;
		Answer4 = answer4;
		Answer = answer;
	}
	
	// Properties
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }
	
	[BsonElement("Question")]
	[BsonRepresentation(BsonType.String)]
	public string Question { get; init; }
	
	[BsonElement("Answer1")]
	[BsonRepresentation(BsonType.String)]
	public string Answer1 { get; init; }
	
	[BsonElement("Answer2")]
	[BsonRepresentation(BsonType.String)]
	public string Answer2 { get; init; }
	
	[BsonElement("Answer3")]
	[BsonRepresentation(BsonType.String)]
	public string Answer3 { get; init; }
	
	[BsonElement("Answer4")]
	[BsonRepresentation(BsonType.String)]
	public string Answer4 { get; init; }
	
	[BsonElement("Answer")]
	[BsonRepresentation(BsonType.Int32)]
	public int Answer { get; init; }
	
}