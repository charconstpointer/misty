using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Misty.Domain.Entities;
using Misty.Domain.Repositories;

namespace Misty.Persistence.Repositories
{
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly ICollection<Article> _articles;

        public ArticlesRepository(ICollection<Article> articles)
        {
            _articles = articles;
        }

        public async Task Save(Article article)
        {
            _articles.Add(article);
        }

        public async Task<Article> Get(int id)
        {
            var a = FindArticle(id);

            return a;
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            return _articles;
        }

        public async Task Update(int id, Article article)
        {
            var a = FindArticle(id);

            //TODO Update article impl
        }

        public async Task Delete(int id)
        {
            var a = FindArticle(id);
            _articles.Remove(a);
        }

        private Article FindArticle(int id)
        {
            var a = _articles.SingleOrDefault(a => a.Id == id);
            if (a is null)
            {
                throw new ApplicationException($"Article with id {id} could not be found");
            }

            return a;
        }
    }
}