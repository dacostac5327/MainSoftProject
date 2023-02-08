using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.BussinesRules
{
    public class UsersBussinesRules
    {
        private readonly IUsersRepositories _repository;
        public UsersBussinesRules(IUsersRepositories repository)
        {
            _repository = repository;
        }

        public async Task<List<Users>> GetUsersAsync()
        {
            return await _repository.GetUsersAsync();
        }
    }
}
