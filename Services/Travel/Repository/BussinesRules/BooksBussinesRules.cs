using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.BussinesRules
{
    public class BooksBussinesRules
    {
        private readonly IBooksRepositories _repository;
        public BooksBussinesRules(IBooksRepositories repository)
        {
            _repository = repository;
        }

        public async Task<List<Books>> GetBooksAsync()
        {
            return await _repository.GetBooksAsync();
        }

        public async Task<Books> GetBookByIdAsync(long ISBN)
        {
            return await _repository.GetBookByIdAsync(ISBN);
        }
        public async Task<Books> PostBooksAsync(Books books)
        {
            return await _repository.PostBooksAsync(books);
        }

        public async Task<Books> PutBooksAsync(Books books)
        {
            return await _repository.PutBooksAsync(books);
        }
    }
}
