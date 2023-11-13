using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PubCrawl.Core.Repo;

namespace PubCrawl.Quiz.Repo;
	
public record AnswerQuizDataModel : IDataModel
{
	// Constructor
	public AnswerQuizDataModel(string? id, string quizID, string userID, int points)
	{
	    Id          = id;
		QuizID = quizID;
		UserID = userID;
		Points = points;
	}
	
	// Properties
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }
	
	[BsonElement("QuizID")]
	[BsonRepresentation(BsonType.String)]
	public string QuizID { get; init; }
	
	[BsonElement("UserID")]
	[BsonRepresentation(BsonType.String)]
	public string UserID { get; init; }
	
	[BsonElement("Points")]
	[BsonRepresentation(BsonType.Int32)]
	public int Points { get; init; }
	
}