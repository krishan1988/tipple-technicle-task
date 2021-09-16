using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.Response;

namespace api.Connector
{
    interface ICocktailConnector
    {
        public Task<Drinks> GetCocktailIDsByIngredient(string ingredient);
        public Task<DrinkDetails> GetCocktailByID(int id);
        public Task<DrinksRandom> GetRandomCocktail();
    }
}
