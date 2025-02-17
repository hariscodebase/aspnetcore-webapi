using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();

        }

        public AuthorWithBookNamesVM GetAuthorWithBookNames(int authorId)
        {
            var author = _context.Authors.Where(a => a.Id == authorId).Select(ab => new AuthorWithBookNamesVM()
            {
                FullName = ab.FullName,
                BookNames = ab.Book_Authors.Select(ba => ba.Book.Title).ToList()
            }).FirstOrDefault();
            return author;
        }
    }
}
