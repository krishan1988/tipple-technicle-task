using api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Connector
{
    public class MockCocktailConnector : ICocktailConnector
    {
        public Task<DrinkDetails> GetCocktailByID(int id)
        {
           if ( id == 17256) {
                new NullReferenceException();
            }
            Task<DrinkDetails> t = Task.Run(() => {
                var d = new DrinkDetails();
                d.drinks = new List<DrinkDetail>();
                var d1 = new DrinkDetail();

                //like this, we can add mockdata to here and im not adding all the mockdata here
                d1.dateModified = "2015-08-18 14:42:59";
                d1.idDrink = "17256";
                d1.strDrink = "Margarita";
                d.drinks.Add(d1);

                return d;
            });
            return t;
        }

        public Task<Drinks> GetCocktailIDsByIngredient(string ingredient)
        {
            Task<Drinks> t = Task.Run(() => {
                var d = new Drinks();
                d.drinks = new List<Drink>();
               var d1 = new Drink();

                //like this, we can add mockdata to here and im not adding all the mockdata here
                d1.idDrink = "17256";
                d1.strDrink = "Martinez 2";
                d1.strDrinkThumb = "https://www.thecocktaildb.com/images/media/drink/fs6kiq1513708455.jpg";

                d.drinks.Add(d1);
                return d;
            });
            return t;
        }

        public Task<DrinksRandom> GetRandomCocktail()
        {
            Task<DrinksRandom> t = Task.Run(() => {
                var d = new DrinksRandom();
                d.drinks = new List<DrinkRandom>();
                var d1 = new DrinkRandom();

                //like this, we can add mockdata to here and im not adding all the mockdata here
                d1.idDrink = "11476";
                d1.strDrink = "Highland Fling Cocktail";
                d1.strCategory = "Ordinary Drink";

                d.drinks.Add(d1);

                return d;
            });
            return t ;
        }
    }
}
