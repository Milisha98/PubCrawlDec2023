namespace PubCrawl.Core.Repo;

public static class RepoHelper
{
    public static string GetCollection<T>() =>
        nameof(T) switch
        {
            "Dare"          => "dares",
            "Location"      => "locations",
            "MessageLog"    => "messageLog",
            "QuizQuestion"  => "quiz-questions",
            "User"          => "users",
            _ => throw new NotImplementedException($"Can't find a matching Collection for Type '{nameof(T)}'")
        };
    
    public static Guid NewIfEmpty(this Guid id) =>
        id == Guid.Empty ? Guid.NewGuid() : id;
}
