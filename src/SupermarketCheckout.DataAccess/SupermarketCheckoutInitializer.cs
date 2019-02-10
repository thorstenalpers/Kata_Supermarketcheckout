namespace SupermarketCheckout.DataAccess
{
    using SupermarketCheckout.DataAccess.Models;
    using System.Linq;

    public class SupermarketCheckoutInitializer
    {
        public static void Initialize(SupermarketCheckoutContext context)
        {
            var initializer = new SupermarketCheckoutInitializer();

            initializer.SeedArticles(context);
            initializer.SeedArticleDiscounts(context);
            initializer.SeedArticlePrices(context);
        }

        public void SeedArticles(SupermarketCheckoutContext context)
        {
            var articles = new[]
            {
                new Article { Name = "Apple" },
                new Article { Name = "Banana" },
                new Article { Name = "Peach" }
            };
            foreach(var article in articles)
            {
                if(context.Articles.FirstOrDefault(x => x.Name == article.Name) == null)
                {
                    context.Articles.Add(article);
                    context.SaveChanges();
                }
            }
        }

        public void SeedArticleDiscounts(SupermarketCheckoutContext context)
        {
            var articleDiscounts = new[]
            {
                new ArticleDiscount { NewPrice = 45, NumberOfArticles = 2, ArticleId = context.Articles.FirstOrDefault(x => x.Name == "Apple").Id },
                new ArticleDiscount { NewPrice = 130, NumberOfArticles = 3, ArticleId = context.Articles.FirstOrDefault(x => x.Name == "Banana").Id }
            };
            foreach (var articleDiscount in articleDiscounts)
            {
                if (context.ArticleDiscounts.FirstOrDefault(x => x.ArticleId == articleDiscount.ArticleId) == null)
                {
                    context.ArticleDiscounts.Add(articleDiscount);
                    context.SaveChanges();
                }
            }
        }

        public void SeedArticlePrices(SupermarketCheckoutContext context)
        {
            var articlePrices = new[]
            {
                new ArticlePrice { UnitPrice = 50, ArticleId = context.Articles.FirstOrDefault(x => x.Name == "Banana").Id},
                new ArticlePrice { UnitPrice = 30, ArticleId = context.Articles.FirstOrDefault(x => x.Name == "Apple").Id},
                new ArticlePrice { UnitPrice = 60, ArticleId = context.Articles.FirstOrDefault(x => x.Name == "Peach").Id}
            };
            foreach (var articlePrice in articlePrices)
            {
                if (context.ArticlePrices.FirstOrDefault(x => x.ArticleId == articlePrice.ArticleId) == null)
                {
                    context.ArticlePrices.Add(articlePrice);
                    context.SaveChanges();
                }
            }
        }
    }
}
