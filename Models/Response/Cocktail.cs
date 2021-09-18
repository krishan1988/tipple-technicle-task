using Newtonsoft.Json;
using System.Collections.Generic;

namespace api.Models.Response
{
   
    public class Cocktail
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Instructions { get; set; }
        public string strIngredient1 { get; set; }
        public string strIngredient2 { get; set; }
        public string strIngredient3 { get; set; }
        public string strIngredient4 { get; set; }
        public object strIngredient5 { get; set; }
        public object strIngredient6 { get; set; }
        public object strIngredient7 { get; set; }
        public object strIngredient8 { get; set; }
        public object strIngredient9 { get; set; }
        public object strIngredient10 { get; set; }
        public object strIngredient11 { get; set; }
        public object strIngredient12 { get; set; }
        public object strIngredient13 { get; set; }
        public object strIngredient14 { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object strIngredient15 { get; set; }
        public string ImageURL { get; set; }
    }
}