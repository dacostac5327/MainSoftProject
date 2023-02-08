using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAuthors_has_BooksRepositories
    {
        public Task<List<Authors_has_Books>> GetAuthors_has_BooksAsync();
        public Task<List<Authors_has_Books>> GetAuthors_has_BooksByAuthorIdAsync(int id);
        public Task<List<Authors_has_Books>> GetAuthors_has_BooksByEditorialIdAsync(int id);
        public Task<Authors_has_Books> PostAuthors_has_BooksAsync(Authors_has_Books authors_Has_Books);
    }
}
