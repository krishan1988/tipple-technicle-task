using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.Response;

namespace api.Connector
{
    interface ICocktailConnector
    {
        public Drinks GetCocktailIDsByIngredient(string ingredient);
        public DrinkDetails GetCocktailByID(int id);
        public DrinksRandom GetRandomCocktail();
    }
}
