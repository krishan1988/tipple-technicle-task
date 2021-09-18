using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using api.Models.Response;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace api.Controllers
{
    [Route("api")]
    [ApiController]
    public class BoozeController : ControllerBase
    {

        ICocktailService cocktailService = new CocktailService();
       
        [HttpGet]
        [Route("search-ingredient/{ingredient}")]
        public ActionResult GetIngredientSearch([FromRoute] string ingredient)
        {
            var cocktailList = new CocktailList();
            cocktailList = cocktailService.GetCocktailListByIngredient(ingredient);
            if (cocktailList == null)
            {
              
                var error = new Error();
                error.error = string.Format("No Drinks found with Ingredient:{0}", ingredient);
                var result = Content(JsonConvert.SerializeObject(error), "application/json; charset=utf-8");
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return result;
            }
            return  ignoreNull(cocktailList); 
        }


        [HttpGet]
        [Route("random")]
        public ActionResult GetRandom()
        {
            var cocktail = new Cocktail();
            cocktail = cocktailService.GetRandomCocktaill();
            return ignoreNull(cocktail);
        }


        private ContentResult ignoreNull( object data) 
        {
            var serilaizeJson = JsonConvert.SerializeObject(data, Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            var result = JsonConvert.DeserializeObject<dynamic>(serilaizeJson);
            return Content(JsonConvert.SerializeObject(result), "application/json");

        }
    }
}