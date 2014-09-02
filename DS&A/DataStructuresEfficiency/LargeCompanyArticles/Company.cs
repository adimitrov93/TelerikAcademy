namespace LargeCompanyArticles
{
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class Company
    {
        private readonly OrderedMultiDictionary<decimal, Article> articles;

        public Company()
        {
            this.articles = new OrderedMultiDictionary<decimal, Article>(true);
        }

        public void AddArticle(Article article)
        {
            this.articles.Add(article.Price, article);
        }

        public void RemoveArticle(Article article)
        {
            this.articles.Remove(article.Price, article);
        }

        public IEnumerable<Article> GetArticlesInRange(decimal from, decimal to)
        {
            return this.articles.Range(from, true, to, true).Values;
        }
    }
}
