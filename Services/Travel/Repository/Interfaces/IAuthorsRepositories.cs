using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAuthorsRepositories
    {
        public Task<List<Authors>> GetAuthorsAsync();

        public Task<Authors> GetAuthorByIdAsync(int id);

        public Task<Authors> PostAuthorsAsync(Authors authors);

        public Task<Authors> PutAuthorsAsync(Authors authors);
    }
}
