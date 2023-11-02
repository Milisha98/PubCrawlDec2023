namespace PubCrawl.Drinks;

public record Drink(DrinkEnum Code, string Name, int Points);

public enum DrinkEnum
{
    BeerMidi,
    BeerPint,
    Wine,
    Sprit,
    Cocktail
};