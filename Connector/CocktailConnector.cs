using api.Models.Response.Outgoing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace api.Connector
{
    public class CocktailConnector : ICocktailConnector
    {
        private HttpClient httpClient = new HttpClient();
        
        public  DrinkDetails GetCocktailByID(int id)
        {
            var urlPath = "https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i=" + id.ToString();
            return getData<DrinkDetails>(urlPath);
        }

        public Drinks GetCocktailIDsByIngredient(string ingredient)
        {
            var  urlPath = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?i=" + ingredient;
            return getData<Drinks>(urlPath);
        }

        public DrinkDetails GetRandomCocktail()
        {
            var urlPath = "https://www.thecocktaildb.com/api/json/v1/1/random.php";
            return getData<DrinkDetails>(urlPath);
        }

        private T getData<T>  (string url )
        {
            HttpWebRequest request = WebRequest.CreateHttp(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8);
            string responseJSON = myStreamReader.ReadToEnd();

            return JsonConvert.DeserializeObject<T>(responseJSON);
        }
    }
}
