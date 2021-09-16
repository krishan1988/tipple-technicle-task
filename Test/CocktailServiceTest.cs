using api.Connector;
using api.Models.Response;
using api.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace api.Test
{
    [TestClass]
    public class CocktailServiceTest
    {
        [TestMethod]
        public void Test_GetCocktailListByIngredient()
        {
            MockCocktailConnector mc = new MockCocktailConnector();
            ICocktailService c = new CocktailService(mc);
            var actual = c.GetCocktailListByIngredient("Gin");
            var expected = new CocktailList();
            Assert.AreEqual(expected,actual);

        }

        [TestMethod]
        public void Test_GetRandomCocktaill()
        {
            MockCocktailConnector mc = new MockCocktailConnector();
            ICocktailService c = new CocktailService(mc);
            var actual = c.GetRandomCocktaill();
            var expected = new Cocktail();
            Assert.AreEqual(expected, actual);
        }
    }
}
