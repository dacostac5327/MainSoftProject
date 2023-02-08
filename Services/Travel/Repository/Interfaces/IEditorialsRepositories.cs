using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IEditorialsRepositories
    {
        public Task<List<Editorials>> GetEditorialsAsync();
        public Task<Editorials> GetEditorialByIdAsync(int id);
        public Task<Editorials> PostEditorialsAsync(Editorials editorials);
        public Task<Editorials> PutEditorialsAsync(Editorials editorials);
    }
}
