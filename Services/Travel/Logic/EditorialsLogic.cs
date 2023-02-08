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
    public class EditorialsLogic : IEditorialsRepositories
    {
        readonly TravelContext db;
        public EditorialsLogic(TravelContext context)
        {
            db = context;
        }

        public async Task<List<Editorials>> GetEditorialsAsync()
        {
            return db.Editorials.ToList();
        }

        public async Task<Editorials> GetEditorialByIdAsync(int id)
        {
            return db.Editorials.Where(e => e.id == id).FirstOrDefault();
        }

        public async Task<Editorials> PostEditorialsAsync(Editorials editorials)
        {
            await db.Editorials.AddAsync(editorials);
            await db.SaveChangesAsync();
            return editorials;
        }

        public async Task<Editorials> PutEditorialsAsync(Editorials editorials)
        {
            var register = db.Editorials.Where(e => e.id == editorials.id).FirstOrDefault();
            if (register != null)
            {
                if (register.name != editorials.name)
                    register.name = editorials.name;
                if (register.campus != editorials.campus)
                    register.campus = editorials.campus;

                db.Entry(register).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }

            return register;
        }
    }
}
