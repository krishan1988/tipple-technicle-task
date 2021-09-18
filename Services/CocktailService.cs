using api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Connector;
using System.Net.Http;
using System.Net;

namespace api.Services
{
    public class CocktailService : ICocktailService
    {

        private ICocktailConnector connector;

        public CocktailService()
        {
            this.connector = new CocktailConnector();
        }

        public CocktailService(MockCocktailConnector c)
        {
            this.connector = c;
        }

        public CocktailList GetCocktailListByIngredient(string ingredient)
        {
            CocktailList cocktailList = new CocktailList();
            cocktailList.Cocktails = new List<Cocktail>();
            Drinks drinks = this.connector.GetCocktailIDsByIngredient(ingredient);
            if (drinks == null) {
                return null;
            }

            foreach (var d in drinks.drinks) {
                var id = Int32.Parse(d.idDrink);
                var cocktail = connector.GetCocktailByID(id);
                foreach (var l in cocktail.drinks.ToArray()) {
                    var c = new Cocktail();
                    c.Id = Int32.Parse(l.idDrink);
                    c.Name = l.strDrink ;
                     c.ImageURL = l.strDrinkThumb != null ?  l.strDrinkThumb.ToString(): "";

                    c.strIngredient1 = l.strIngredient1;
                    c.strIngredient2 = l.strIngredient2;
                    c.strIngredient3 = l.strIngredient3;
                    c.strIngredient4 = l.strIngredient4;
                    c.strIngredient5 = l.strIngredient5;
                    c.strIngredient6 = l.strIngredient6;
                    c.strIngredient7 = l.strIngredient7;
                    c.strIngredient8 = l.strIngredient8;
                    c.strIngredient9 = l.strIngredient9;
                    c.strIngredient10 = l.strIngredient10;
                    c.strIngredient11 = l.strIngredient11;
                    c.strIngredient12 = l.strIngredient12;
                    c.strIngredient13 = l.strIngredient13;
                    c.strIngredient14 = l.strIngredient14;
                    c.strIngredient15 = l.strIngredient15;

                    c.Instructions = l.strInstructions;
                    cocktailList.Cocktails.Add(c);
                }  
            }

            return cocktailList;
        }

        public Cocktail GetRandomCocktaill()
        {
            CocktailList cocktailList = new CocktailList();
            cocktailList.Cocktails = new List<Cocktail>();

            foreach (var drinkDetails in connector.GetRandomCocktail().drinks.ToArray())
            {
                var cocktail = new Cocktail();
                cocktail.Id = Int32.Parse(drinkDetails.idDrink);
                cocktail.Name = drinkDetails.strDrink;
                
                cocktail.ImageURL = drinkDetails.strDrinkThumb != null ?  drinkDetails.strDrinkThumb.ToString(): "";

                cocktail.strIngredient1 = drinkDetails.strIngredient1;
                cocktail.strIngredient2 = drinkDetails.strIngredient2;
                cocktail.strIngredient3 = drinkDetails.strIngredient3;
                cocktail.strIngredient4 = drinkDetails.strIngredient4;
                cocktail.strIngredient5 = drinkDetails.strIngredient5;
                cocktail.strIngredient6 = drinkDetails.strIngredient6;
                cocktail.strIngredient7 = drinkDetails.strIngredient7;
                cocktail.strIngredient8 = drinkDetails.strIngredient8;
                cocktail.strIngredient9 = drinkDetails.strIngredient9;
                cocktail.strIngredient10 = drinkDetails.strIngredient10;
                cocktail.strIngredient11 = drinkDetails.strIngredient11;
                cocktail.strIngredient12 = drinkDetails.strIngredient12;
                cocktail.strIngredient13 = drinkDetails.strIngredient13;
                cocktail.strIngredient14 = drinkDetails.strIngredient14;
                cocktail.strIngredient15 = drinkDetails.strIngredient15;

                cocktail.Instructions = drinkDetails.strInstructions;
                cocktailList.Cocktails.Add(cocktail);
            }
            
            var radom = new Random();
            var index = radom.Next(cocktailList.Cocktails.Count);
            return cocktailList.Cocktails[index];
        }
    }
}
