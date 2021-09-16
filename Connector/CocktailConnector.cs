using api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace api.Connector
{
    public class CocktailConnector : ICocktailConnector
    {
        HttpClient httpClient = new HttpClient();
        
        public  Task<DrinkDetails> GetCocktailByID(int id)
        {

            var urlPath = "https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i=11007";
            var  httpResponse =  httpClient.GetAsync(urlPath);
            var dls= httpResponse.Result.Content.ReadAsAsync<DrinkDetails>();
            return dls;
         
        }

        public Task<Drinks> GetCocktailIDsByIngredient(string ingredient)
        {
           var  urlPath = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?i=" + ingredient;
            var httpResponse = httpClient.GetAsync(urlPath);
            return httpResponse.Result.Content.ReadAsAsync<Drinks>();
        }

        public Task<DrinksRandom> GetRandomCocktail()
        {
           
            var urlPath = "https://www.thecocktaildb.com/api/json/v1/1/random.php";
            var httpResponse = httpClient.GetAsync(urlPath);
           var rc =  httpResponse.Result.Content.ReadAsAsync<DrinksRandom>();
            return rc;
        }
    }
}
