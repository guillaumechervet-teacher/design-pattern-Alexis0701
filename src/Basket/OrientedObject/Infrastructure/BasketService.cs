using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Basket.OrientedObject.Domain;
using Newtonsoft.Json;

namespace Basket.OrientedObject.Infrastructure
{

    public class BasketService {
        public Domain.Basket GetBasket(IList<BasketLineArticle> basketLineArticles) {
            // here your code implementation
            var list = new List<BasketLine>();
            foreach (var basketLineArticle in basketLineArticles)
            {
                var articleDatabase = GetArticleFromDatabase(basketLineArticle.Id);

                list.Add(new BasketLine(new Article(100, "jeux"), 1 ));
                list.Add(new BasketLine(new Article(59, "cuisine"), 4));
                list.Add(new BasketLine(new Article(580, "foot"), 3));
                list.Add(new BasketLine(new Article(11, "sport"), 5));
                list.Add(new BasketLine(new Article(1, "velo"), 2));

            }

            return new Domain.Basket(list);
         }
    
    private ArticleDatabase GetArticleFromDatabase(string id)
    {
        // Retrive article from database 
        var codeBase = Assembly.GetExecutingAssembly().CodeBase;
        var uri = new UriBuilder(codeBase);
        var path = Uri.UnescapeDataString(uri.Path);
        var assemblyDirectory = Path.GetDirectoryName(path);
        var jsonPath = Path.Combine(assemblyDirectory, "article-database.json");
        IList<ArticleDatabase> articleDatabases =
            JsonConvert.DeserializeObject<List<ArticleDatabase>>(File.ReadAllText(jsonPath));
        var article = articleDatabases.First(articleDatabase => { return articleDatabase.Id == id; });
            return article;
    }
    }
}