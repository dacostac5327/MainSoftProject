using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class UsersLogic : IUsersRepositories
    {
        readonly TravelContext db;
        public UsersLogic(TravelContext context)
        {
            db = context;
        }

        public async Task<List<Users>> GetUsersAsync()
        {
            return db.Users.ToList();
        }
    }
}
