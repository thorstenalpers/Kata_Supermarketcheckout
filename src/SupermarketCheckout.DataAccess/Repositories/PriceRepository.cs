namespace SupermarketCheckout.DataAccess.Repositories
{
    using SupermarketCheckout.DataAccess.Models;
    using SupermarketCheckout.DataAccess.Repositories.Base;

    public class PriceRepository : EfRepository<ArticlePrice>, IPriceRepository
    {
        public PriceRepository(SupermarketCheckoutContext dbContext) : base(dbContext)
        {
        }
    }
}
