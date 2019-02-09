namespace SupermarketCheckout.BusinessLogic.Models
{
    public class BasketItemDto
    {
        public ArticleDto Article { get; set; }

        public int? NumberOfArticles { get; set; }

        public ArticleDiscountDto ArticleDiscount { get; set; }

        public ArticlePriceDto ArticlePrice { get; set; }
    }
}
