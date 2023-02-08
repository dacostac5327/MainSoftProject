using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBooksRepositories
    {
        public Task<List<Books>> GetBooksAsync();

        public Task<Books> GetBookByIdAsync(long ISBN);

        public Task<Books> PostBooksAsync(Books books);

        public Task<Books> PutBooksAsync(Books books);
    }
}
