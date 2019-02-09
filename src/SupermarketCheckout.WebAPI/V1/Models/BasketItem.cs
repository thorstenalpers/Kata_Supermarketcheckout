using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketCheckout.WebAPI.V1.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 
    /// </summary>
    public class BasketItem
    {
        /// <summary>
        /// the supermarket article
        /// </summary>
        [Required]
        public Article Article { get; set; }

        /// <summary>
        /// Number of articles in the basket
        /// </summary>
        [Required]
        public uint? NumberOfArticles { get; set; }

        /// <summary>
        /// the discount
        /// </summary>
        [Required]
        public ArticleDiscount ArticleDiscount { get; set; }

        /// <summary>
        /// Unit price
        /// </summary>
        [Required]
        public ArticlePrice ArticlePrice { get; set; }

    }
}
