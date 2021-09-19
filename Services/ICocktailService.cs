using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.Response;

namespace api.Services
{
    public interface ICocktailService
    {
        public CocktailList GetCocktailListByIngredient(string ingredient);
        public Cocktail GetRandomCocktaill();
    }
}
