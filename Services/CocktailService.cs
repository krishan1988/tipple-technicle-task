using api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Connector;
using System.Net.Http;
using System.Net;
using api.Models.Response.Outgoing;

namespace api.Services
{
    public class CocktailService : ICocktailService
    {

        private ICocktailConnector connector;
       
        public CocktailService()
        {
            this.connector = new CocktailConnector();
        }

        public CocktailService(MockCocktailConnector cocktailService)
        {
            this.connector = cocktailService;
        }

        public CocktailList GetCocktailListByIngredient(string ingredient)
        {
            CocktailList cocktailList = new CocktailList();
            cocktailList.Cocktails = new List<Cocktail>();
            Drinks drinks = this.connector.GetCocktailIDsByIngredient(ingredient);
            if (drinks == null) {
                return null;
            }

            
            var tasks = new List<Task<DrinkDetails>>();

            Func<object, DrinkDetails> action = (object obj) =>
             {
                 int id = (int)obj;
                 return connector.GetCocktailByID(id);
             };

            foreach (var drink in drinks.drinks) {
                var id = Int32.Parse(drink.idDrink);
                tasks.Add(Task<DrinkDetails>.Factory.StartNew(action,id));
            }

            // Wait until all task.
            Task.WaitAll(tasks.ToArray());

            foreach (var task in tasks)
            {
                foreach (var drinkDetail in task.Result.drinks)
                {
                    cocktailList.Cocktails.Add(getCocktail(drinkDetail));
                }
            }


            // Sequential code
            //foreach (var drink in drinks.drinks) {
            //    var id = Int32.Parse(drink.idDrink);
            //    var cocktail = connector.GetCocktailByID(id);
            //    foreach (var drinkDetail in cocktail.drinks) {
            //        cocktailList.Cocktails.Add(getCocktail(drinkDetail));
            //    }  
            //}

            return cocktailList;
        }

        public Cocktail GetRandomCocktaill()
        {
            CocktailList cocktailList = new CocktailList();
            cocktailList.Cocktails = new List<Cocktail>();
            foreach (var drinkDetail in connector.GetRandomCocktail().drinks)
            {
                cocktailList.Cocktails.Add(getCocktail(drinkDetail));
            }
            
            var radom = new Random();
            var index = radom.Next(cocktailList.Cocktails.Count);
            return cocktailList.Cocktails[index];
        }

        private Cocktail getCocktail(DrinkDetail drinkDetail)
        {
            var cocktail = new Cocktail();
            cocktail.Id = Int32.Parse(drinkDetail.idDrink);
            cocktail.Name = drinkDetail.strDrink;

            cocktail.ImageURL = drinkDetail.strDrinkThumb != null ? drinkDetail.strDrinkThumb.ToString() : "";

            cocktail.strIngredient1 = drinkDetail.strIngredient1;
            cocktail.strIngredient2 = drinkDetail.strIngredient2;
            cocktail.strIngredient3 = drinkDetail.strIngredient3;
            cocktail.strIngredient4 = drinkDetail.strIngredient4;
            cocktail.strIngredient5 = drinkDetail.strIngredient5;
            cocktail.strIngredient6 = drinkDetail.strIngredient6;
            cocktail.strIngredient7 = drinkDetail.strIngredient7;
            cocktail.strIngredient8 = drinkDetail.strIngredient8;
            cocktail.strIngredient9 = drinkDetail.strIngredient9;
            cocktail.strIngredient10 = drinkDetail.strIngredient10;
            cocktail.strIngredient11 = drinkDetail.strIngredient11;
            cocktail.strIngredient12 = drinkDetail.strIngredient12;
            cocktail.strIngredient13 = drinkDetail.strIngredient13;
            cocktail.strIngredient14 = drinkDetail.strIngredient14;
            cocktail.strIngredient15 = drinkDetail.strIngredient15;

            cocktail.Instructions = drinkDetail.strInstructions;
            return cocktail;
        }
    }
}
