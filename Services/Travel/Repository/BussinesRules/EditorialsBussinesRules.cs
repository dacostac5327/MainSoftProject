using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.BussinesRules
{
    public class EditorialsBussinesRules
    {
        private readonly IEditorialsRepositories _repository;
        public EditorialsBussinesRules(IEditorialsRepositories repository)
        {
            _repository = repository;
        }

        public async Task<List<Editorials>> GetEditorialsAsync()
        {
            return await _repository.GetEditorialsAsync();
        }

        public async Task<Editorials> GetEditorialByIdAsync(int id)
        {
            return await _repository.GetEditorialByIdAsync(id);
        }
        
        public async Task<Editorials> PostEditorialsAsync(Editorials editorials)
        {
            return await _repository.PostEditorialsAsync(editorials);
        }
        
        public async Task<Editorials> PutEditorialsAsync(Editorials editorials)
        {
            return await _repository.PutEditorialsAsync(editorials);
        }
    }
}
