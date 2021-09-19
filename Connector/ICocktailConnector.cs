using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.Response.Outgoing;

namespace api.Connector
{
    interface ICocktailConnector
    {
        public Drinks GetCocktailIDsByIngredient(string ingredient);
        public DrinkDetails GetCocktailByID(int id);
        public DrinkDetails GetRandomCocktail();
    }
}
