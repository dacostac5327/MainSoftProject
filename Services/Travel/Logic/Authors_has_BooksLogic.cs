using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Authors_has_BooksLogic : IAuthors_has_BooksRepositories
    {
        readonly TravelContext db;
        public Authors_has_BooksLogic(TravelContext context)
        {
            db = context;
        }

        public async Task<List<Authors_has_Books>> GetAuthors_has_BooksAsync()
        {
            var query = from ab in db.Authors_has_Books
                        join a in db.Authors on ab.authors_id equals a.id
                        join b in db.Books on ab.books_ISBN equals b.ISBN
                        select new Authors_has_Books()
                        {
                            authors_id = ab.authors_id,
                            books_ISBN = ab.books_ISBN,
                            nameAuthor = a.name,
                            surnamesAuthor = a.surnames,
                            title = b.title,
                            synopsis = b.synopsis,
                            n_pages = b.n_pages
                        };
            return query.ToList();
        }

        public async Task<List<Authors_has_Books>> GetAuthors_has_BooksByAuthorIdAsync(int id)
        {
            var query = from ab in db.Authors_has_Books
                        join a in db.Authors on ab.authors_id equals a.id
                        join b in db.Books on ab.books_ISBN equals b.ISBN
                        where ab.authors_id == id
                        select new Authors_has_Books()
                        {
                            authors_id = ab.authors_id,
                            books_ISBN = ab.books_ISBN,
                            nameAuthor = a.name,
                            surnamesAuthor = a.surnames,
                            title = b.title,
                            synopsis = b.synopsis,
                            n_pages = b.n_pages
                        };
            return query.ToList();
        }

        
        public async Task<List<Authors_has_Books>> GetAuthors_has_BooksByEditorialIdAsync(int id)
        {
            var query = from ab in db.Authors_has_Books
                        join a in db.Authors on ab.authors_id equals a.id
                        join b in db.Books on ab.books_ISBN equals b.ISBN
                        where b.editorials_id == id
                        select new Authors_has_Books()
                        {
                            authors_id = ab.authors_id,
                            books_ISBN = ab.books_ISBN,
                            nameAuthor = a.name,
                            surnamesAuthor = a.surnames,
                            title = b.title,
                            synopsis = b.synopsis,
                            n_pages = b.n_pages
                        };
            return query.ToList();
        }

        public async Task<Authors_has_Books> PostAuthors_has_BooksAsync(Authors_has_Books authors_Has_Books)
        {
            await db.Authors_has_Books.AddAsync(authors_Has_Books);
            await db.SaveChangesAsync();
            return authors_Has_Books;
        }
    }
}
