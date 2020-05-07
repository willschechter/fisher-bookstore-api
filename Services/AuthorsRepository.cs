using System.Collections.Generic;
using Fisher.Bookstore.Data;
using Fisher.Bookstore.Models;

namespace Fisher.Bookstore.Services
{

    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly BookstoreContext db;

        public AuthorsRepository(BookstoreContext db)
        {
            this.db = db;
        }

        public int AddAuthor(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
            return author.Id;
        }

        public bool AuthorExists(int authorid)
        {
            return (db.Authors.Find(authorid) != null);

        }

        public void DeleteAuthor(int authorid)
        {
            var author = db.Authors.Find(authorid);
            db.Authors.Remove(author);
            db.SaveChanges();
        }

        public Author GetAuthor(int authorid)
        {
            return db.Authors.Find(authorid);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return db.Authors;
        }

        public void UpdateAuthor(Author author)
        {
            var updateAuthor = db.Authors.Find(author.Id);
            updateAuthor.Name = author.Name;
            db.Authors.Update(updateAuthor);
            db.SaveChanges();
        }
    }
}
