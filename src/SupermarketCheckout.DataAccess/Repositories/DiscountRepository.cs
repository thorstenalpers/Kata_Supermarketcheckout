namespace SupermarketCheckout.DataAccess.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using SupermarketCheckout.DataAccess.Models;
    using SupermarketCheckout.DataAccess.Repositories.Base;
    using System.Linq;
    using System.Threading.Tasks;

    public class DiscountRepository : EfRepository<ArticleDiscount>, IDiscountRepository
    {
        public DiscountRepository(SupermarketCheckoutContext dbContext) : base(dbContext)
        {
        }
    }
}
