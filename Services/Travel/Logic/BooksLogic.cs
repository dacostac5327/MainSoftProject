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
    public class BooksLogic : IBooksRepositories
    {
        readonly TravelContext db;
        public BooksLogic(TravelContext context)
        {
            db = context;
        }

        public async Task<List<Books>> GetBooksAsync()
        {
            return db.Books.ToList();
        }

        public async Task<Books> GetBookByIdAsync(long ISBN)
        {
            var query = from b in db.Books
                        join ab in db.Authors_has_Books on b.ISBN equals ab.books_ISBN
                        join a in db.Authors on ab.authors_id equals a.id
                        where b.ISBN == ISBN
                        select new Books()
                        {
                            ISBN = b.ISBN,
                            editorials_id = b.editorials_id,
                            title = b.title,
                            synopsis = b.synopsis,
                            n_pages = b.n_pages,
                            nameAuthor = a.name,
                            surnamesAuthor = a.surnames
                        };

            return query.FirstOrDefault();
        }

        public async Task<Books> PostBooksAsync(Books books)
        {
            await db.Books.AddAsync(books);
            await db.SaveChangesAsync();
            return books;
        }

        public async Task<Books> PutBooksAsync(Books books)
        {
            var register = db.Books.Where(b => b.ISBN == books.ISBN).FirstOrDefault();
            if (register != null)
            {
                if (register.editorials_id != books.editorials_id)
                    register.editorials_id = books.editorials_id;
                if (register.title != books.title)
                    register.title = books.title;
                if (register.synopsis != books.synopsis)
                    register.synopsis = books.synopsis;
                if (register.n_pages != books.n_pages)
                    register.n_pages = books.n_pages;

                db.Entry(register).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }

            return register;
        }
    }
}
