using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.BussinesRules
{
    public class Authors_has_BooksBussinesRules
    {
        private readonly IAuthors_has_BooksRepositories _repository;
        public Authors_has_BooksBussinesRules(IAuthors_has_BooksRepositories repository)
        {
            _repository = repository;
        }
        public async Task<List<Authors_has_Books>> GetAuthors_has_BooksAsync()
        {
            return await _repository.GetAuthors_has_BooksAsync();
        }

        public async Task<List<Authors_has_Books>> GetAuthors_has_BooksByAuthorIdAsync(int id)
        {
            return await _repository.GetAuthors_has_BooksByAuthorIdAsync(id);
        }

        public async Task<List<Authors_has_Books>> GetAuthors_has_BooksByEditorialIdAsync(int id)
        {
            return await _repository.GetAuthors_has_BooksByEditorialIdAsync(id);
        }
        
        public async Task<Authors_has_Books> PostAuthors_has_BooksAsync(Authors_has_Books authors_Has_Books)
        {
            return await _repository.PostAuthors_has_BooksAsync(authors_Has_Books);
        }
    }
}
