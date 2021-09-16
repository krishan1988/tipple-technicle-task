using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.Response;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api")]
    [ApiController]
    public class BoozeController : ControllerBase
    {

        ICocktailService s = new CocktailService();
        
        [HttpGet]
        [Route("search-ingredient/{ingredient}")]
        public async Task<IActionResult> GetIngredientSearch([FromRoute] string ingredient)
        {

            // Multiple HTTP calls (multithread) - Speed improvement.
            // Implement service layer and cocktaildb connector with interfaces.
            var cocktailList = new CocktailList();
            // TODO - Search the CocktailDB for cocktails with the ingredient given, and return the cocktails
            // https://www.thecocktaildb.com/api/json/v1/1/filter.php?i=Gin
            // You will need to populate the cocktail details from
            // https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i=11007
            // The calculate and fill in the meta object
            cocktailList = s.GetCocktailListByIngredient(ingredient);
            return Ok(cocktailList);
        }

        [HttpGet]
        [Route("random")]
        public async Task<IActionResult> GetRandom()
        {
            var cocktail = new Cocktail();
            // TODO - Go and get a random cocktail
            // https://www.thecocktaildb.com/api/json/v1/1/random.php
            cocktail = s.GetRandomCocktaill();
            return Ok(cocktail);
        }
    }
}