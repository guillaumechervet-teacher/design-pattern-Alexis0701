using Basket;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BasketTest
{

    [TestClass]
    public class BasketOperation_CalculateBasketAmoutShould
    {
        private object ImperativeProgramming;

        public class BasketTest
        {
            public List<BasksetLineArticle> BasketLineArticles { get; set; }
            public int ExpectedPrice { get; set; }
        }

        private static IEnumerable<object[]> Baskets
        {
            get
            {
                return new[]
                { new object[] {
                    new BasketTest() { BasketLineArticles = new List<BasksetLineArticle>
                    {
                        new BasksetLineArticle { Id = "1", Number = 12, Label = "Banana" },
                        new BasksetLineArticle { Id = "2", Number = 1, Label = "Fridge electrolux" },
                        new BasksetLineArticle { Id = "3", Number = 4, Label = "Chair" }
                    },
                        ExpectedPrice = 84868 }
                }, new object[] {
                    new BasketTest() { BasketLineArticles = new List<BasksetLineArticle>
                    {
                        new BasksetLineArticle { Id = "1", Number = 20, Label = "Banana" },
                        new BasksetLineArticle { Id = "3", Number = 6, Label = "Chair" }
                    },
                        ExpectedPrice = 37520 }
                    },
                };
            }
        }

        [TestMethod]
        [DynamicData("Baskets")]
        public void ReturnCorrectAmoutGivenBasket(BasketTest basketTest)
        {
            var basKetService = new BasketService();
            var basketOperation = new BasketOperation(basKetService);
            var amountTotal = Basket.BasketOperation.CalculateAmout(basketTest.BasketLineArticles);
            Assert.AreEqual(amountTotal, basketTest.ExpectedPrice);
        }
    }
}
