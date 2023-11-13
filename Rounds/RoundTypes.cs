using PubCrawl.Locations.Repo;
using PubCrawl.Users.Repo;

namespace PubCrawl.Rounds;

public record RoundID(Guid ID);
public record RoundTypes(RoundID RoundId, LocationDataModel Location, bool IsActive);
public record Verses(RoundID RoundId, UserDataModel Player1, UserDataModel Player2);
