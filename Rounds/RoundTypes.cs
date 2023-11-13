using PubCrawl.Locations.Repo;
using PubCrawl.Users.Repo;

namespace PubCrawl.Rounds;

public record RoundTypes(int RoundID, LocationDataModel Location, bool IsActive);
public record Verses(int RoundId, UserDataModel Player1, UserDataModel Player2);
