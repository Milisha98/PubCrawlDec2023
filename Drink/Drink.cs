namespace PubCrawl.Drinks;

public record Drink(DrinkEnum code, string Name, int Points);

public enum DrinkEnum
{
    BeerMidi,
    BeerPint,
    Wine,
    Sprit,
    Cocktail
};s