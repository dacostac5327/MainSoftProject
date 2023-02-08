using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class AuthorsLogic : IAuthorsRepositories
    {
        readonly TravelContext db;
        public AuthorsLogic(TravelContext context)
        {
            db = context;
        }

        public async Task<List<Authors>> GetAuthorsAsync()
        {
            return db.Authors.ToList();
        }

        public async Task<Authors> GetAuthorByIdAsync(int id)
        {
            return db.Authors.Where(a => a.id == id).FirstOrDefault();
        }

        public async Task<Authors> PostAuthorsAsync(Authors authors)
        {
            await db.Authors.AddAsync(authors);
            await db.SaveChangesAsync();
            return authors;
        }

        public async Task<Authors> PutAuthorsAsync(Authors authors)
        {
            var register = db.Authors.Where(a => a.id == authors.id).FirstOrDefault();
            if (register != null)
            {
                if (register.name != authors.name)
                    register.name = authors.name;
                if (register.surnames != authors.surnames)
                    register.surnames = authors.surnames;

                db.Entry(register).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }

            return register;
        }
    }
}
