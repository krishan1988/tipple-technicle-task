using api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Connector;

namespace api.Services
{
    public class CocktailService : ICocktailService
    {

        private ICocktailConnector connector;

        public CocktailService()
        {
            this.connector = new CocktailConnector();
        }
        public CocktailList GetCocktailListByIngredient(string ingredient)
        {
            CocktailList cocktailList = new CocktailList();
            cocktailList.Cocktails = new List<Cocktail>();
            Task<Drinks> drinks = this.connector.GetCocktailIDsByIngredient(ingredient);
            foreach (var d in drinks.Result.drinks.ToArray()) {
                var id = Int32.Parse(d.idDrink);
                var cocktail = connector.GetCocktailByID(id);
                if (cocktail.Result.drinkDetails == null){
                    continue;
                }
                foreach (var l in cocktail.Result.drinkDetails.ToArray()) {
                    var c = new Cocktail();
                    c.Id = Int32.Parse(l.idDrink);
                    c.Name = l.strDrink ;
                    c.ImageURL = l.strImageSource;
                    c.Ingredients = new List<object>();
                    c.Ingredients.Add(l.strIngredient1);
                    c.Ingredients.Add(l.strIngredient2);
                    c.Ingredients.Add(l.strIngredient3);
                    c.Ingredients.Add(l.strIngredient4);
                    c.Ingredients.Add(l.strIngredient5);
                    c.Ingredients.Add(l.strIngredient6);
                    c.Ingredients.Add(l.strIngredient7);
                    c.Ingredients.Add(l.strIngredient8);
                    c.Ingredients.Add(l.strIngredient9);
                    c.Ingredients.Add(l.strIngredient10);
                    c.Ingredients.Add(l.strIngredient11);
                    c.Ingredients.Add(l.strIngredient12);
                    c.Ingredients.Add(l.strIngredient13);
                    c.Ingredients.Add(l.strIngredient14);
                    c.Ingredients.Add(l.strIngredient15);
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

            foreach (var d in connector.GetRandomCocktail().Result.drinks.ToArray())
            {
                var c = new Cocktail();
                c.Id = Int32.Parse(d.idDrink);
                c.Name = d.strDrink;
                //c.ImageURL = d.strImageSource.ToString();
                c.Ingredients = new List<object>();
                c.Ingredients.Add(d.strIngredient1);
                c.Ingredients.Add(d.strIngredient2);
                c.Ingredients.Add(d.strIngredient3);
                c.Ingredients.Add(d.strIngredient4);
                c.Ingredients.Add(d.strIngredient5);
                c.Ingredients.Add(d.strIngredient6);
                c.Ingredients.Add(d.strIngredient7);
                c.Ingredients.Add(d.strIngredient8);
                c.Ingredients.Add(d.strIngredient9);
                c.Ingredients.Add(d.strIngredient10);
                c.Ingredients.Add(d.strIngredient11);
                c.Ingredients.Add(d.strIngredient12);
                c.Ingredients.Add(d.strIngredient13);
                c.Ingredients.Add(d.strIngredient14);
                c.Ingredients.Add(d.strIngredient15);
                c.Instructions = d.strInstructions;
                cocktailList.Cocktails.Add(c);
            }
            
            var radom = new Random();
            var index = radom.Next(cocktailList.Cocktails.Count);
            return cocktailList.Cocktails[index];
        }
    }
}
