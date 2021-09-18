using api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Connector
{
    public class MockCocktailConnector : ICocktailConnector
    {
        public DrinkDetails GetCocktailByID(int id)
        {
           
                var drinkDetails = new DrinkDetails();
                drinkDetails.drinks = new List<DrinkDetail>();
                var drinkDetail = new DrinkDetail();

                //like this, we can add mockdata to here and im not adding all the mockdata here
                drinkDetail.dateModified = "2015-08-18 14:42:59";
                drinkDetail.idDrink = "17256";
                drinkDetail.strDrink = "Margarita";

                drinkDetails.drinks.Add(drinkDetail);

                return drinkDetails;
           
        }

        public Drinks GetCocktailIDsByIngredient(string ingredient)
        {
            var drinkList = new Drinks();
            drinkList.drinks = new List<Drink>();
            var drink = new Drink();

            drink.idDrink = "17256";
            drink.strDrink = "Martinez 2";
            drink.strDrinkThumb = "https://www.thecocktaildb.com/images/media/drink/fs6kiq1513708455.jpg";

            drinkList.drinks.Add(drink);
            return drinkList;
        }

        public DrinksRandom GetRandomCocktail()
        {
            var drinksRandom = new DrinksRandom();
            drinksRandom.drinks = new List<DrinkRandom>();
            var drinkRandom = new DrinkRandom();

            drinkRandom.idDrink = "11476";
            drinkRandom.strDrink = "Highland Fling Cocktail";
            drinkRandom.strCategory = "Ordinary Drink";

            drinksRandom.drinks.Add(drinkRandom);
            return drinksRandom;
        
        }
    }
}
