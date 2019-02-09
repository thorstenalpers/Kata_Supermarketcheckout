using System;

namespace SupermarketCheckout.BusinessLogic.Models
{
    /// <summary>
    /// Representation of a supermarket article
    /// </summary>
    public class ArticleDto : IEquatable<ArticleDto>
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public bool Equals(ArticleDto other)
        {
            if (other == null) return false;
            return other.Id == this.Id &&
                other.Name == this.Name;
        }

        public override bool Equals(object obj)
        {
            var obj2 = (ArticleDto)obj;
            return Equals(obj as ArticleDto);
        }

        public override int GetHashCode()
        {
            // don't use GetHashCode
            return 0;
        }
    }
}
