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

        public CocktailService(MockCocktailConnector c)
        {
            this.connector = c;
        }

        public CocktailList GetCocktailListByIngredient(string ingredient)
        {
            CocktailList cocktailList = new CocktailList();
            cocktailList.Cocktails = new List<Cocktail>();
            Task<Drinks> drinks = this.connector.GetCocktailIDsByIngredient(ingredient);

            foreach (var d in drinks.Result.drinks.ToArray()) {
                var id = Int32.Parse(d.idDrink);
                var cocktail = connector.GetCocktailByID(id);
                if (cocktail.Result.drinks == null){
                    continue;
                }
                foreach (var l in cocktail.Result.drinks.ToArray()) {
                    var c = new Cocktail();
                    c.Id = Int32.Parse(l.idDrink);
                    c.Name = l.strDrink ;
                     c.ImageURL = l.strDrinkThumb != null ?  l.strDrinkThumb.ToString(): "";
                    c.Ingredients = new List<object>();
                    if( l.strIngredient1 !=null)
                        c.Ingredients.Add(l.strIngredient1);

                    if (l.strIngredient2 != null)
                        c.Ingredients.Add(l.strIngredient2);

                    if (l.strIngredient3 != null)
                        c.Ingredients.Add(l.strIngredient3);

                    if (l.strIngredient4 != null)
                        c.Ingredients.Add(l.strIngredient4);

                    if (l.strIngredient5 != null)
                        c.Ingredients.Add(l.strIngredient5);
                   
                    if (l.strIngredient6 != null)
                        c.Ingredients.Add(l.strIngredient6);
                   
                    if (l.strIngredient7 != null)
                        c.Ingredients.Add(l.strIngredient7);
                  
                    if (l.strIngredient8 != null)
                        c.Ingredients.Add(l.strIngredient8);
                   
                    if (l.strIngredient9 != null)
                        c.Ingredients.Add(l.strIngredient9);
                    
                    if (l.strIngredient10 != null)
                        c.Ingredients.Add(l.strIngredient10);
                   
                    if (l.strIngredient11 != null)
                        c.Ingredients.Add(l.strIngredient11);
              
                    if (l.strIngredient12 != null)
                        c.Ingredients.Add(l.strIngredient12);
                 
                    if (l.strIngredient13 != null)
                        c.Ingredients.Add(l.strIngredient13);
                   
                    if (l.strIngredient14 != null)
                        c.Ingredients.Add(l.strIngredient14);
                  
                    if (l.strIngredient15 != null)
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
                
                c.ImageURL = d.strDrinkThumb != null ?  d.strDrinkThumb.ToString(): "";

                c.Ingredients = new List<object>();
                if(d.strIngredient1 != null)
                c.Ingredients.Add(d.strIngredient1);

                if (d.strIngredient2 != null)
                    c.Ingredients.Add(d.strIngredient2);

                if (d.strIngredient3 != null)
                    c.Ingredients.Add(d.strIngredient3);

                if (d.strIngredient4 != null)
                    c.Ingredients.Add(d.strIngredient4);

                if (d.strIngredient5 != null)
                    c.Ingredients.Add(d.strIngredient5);

                if (d.strIngredient6 != null)
                    c.Ingredients.Add(d.strIngredient6);

                if (d.strIngredient7 != null)
                    c.Ingredients.Add(d.strIngredient7);

                if (d.strIngredient8 != null)
                    c.Ingredients.Add(d.strIngredient8);

                if (d.strIngredient9 != null)
                    c.Ingredients.Add(d.strIngredient9);

                if (d.strIngredient10 != null)
                    c.Ingredients.Add(d.strIngredient10);

                if (d.strIngredient11 != null)
                    c.Ingredients.Add(d.strIngredient11);

                if (d.strIngredient12 != null)
                    c.Ingredients.Add(d.strIngredient12);

                if (d.strIngredient13 != null)
                    c.Ingredients.Add(d.strIngredient13);

                if (d.strIngredient14 != null)
                    c.Ingredients.Add(d.strIngredient14);

                if (d.strIngredient15 != null)
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
