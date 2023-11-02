namespace PubCrawl.Drinks;

public class DrinksReadRepo
{
    public List<DrinkEnum> ListDrinkCodes() =>
        new()
        {
            DrinkEnum.BeerMidi,
            DrinkEnum.BeerPint,
            DrinkEnum.Wine,
            DrinkEnum.Sprit,
            DrinkEnum.Cocktail
        };

    public List<Drink> ListDrinks() => 
        ListDrinkCodes()
            .Select(drinkCode => drinkCode.ToDrink())
            .ToList();

}
