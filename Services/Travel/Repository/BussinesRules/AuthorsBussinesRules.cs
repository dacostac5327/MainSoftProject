using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.BussinesRules
{
    public class AuthorsBussinesRules
    {
        private readonly IAuthorsRepositories _repository;
        public AuthorsBussinesRules(IAuthorsRepositories repository)
        {
            _repository = repository;
        }

        public async Task<List<Authors>> GetAuthorsAsync()
        {
            return await _repository.GetAuthorsAsync();
        }

        public async Task<Authors> GetAuthorByIdAsync(int id)
        {
            return await _repository.GetAuthorByIdAsync(id);
        }

        public async Task<Authors> PostAuthorsAsync(Authors authors)
        {
            return await _repository.PostAuthorsAsync(authors);
        }

        public async Task<Authors> PutAuthorsAsync(Authors authors)
        {
            return await _repository.PutAuthorsAsync(authors);
        }
    }
}
