using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                CoverUrl = book.CoverUrl,
                Genre = book.Genre,
                Author = book.Author,
                DateAdded = DateTime.Now
            };
            _context.books.Add(_book);
            _context.SaveChanges();

        }

        public IEnumerable<Book> GetBooks() => _context.books;

        public Book GetBookById(int id) => _context.books.FirstOrDefault(x => x.Id == id);

        public Book UpdateBookById(int bookId, BookVM book)
        {
            var _book = _context.books.FirstOrDefault(n => n.Id == bookId);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.CoverUrl = book.CoverUrl;
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.DateAdded = DateTime.Now;

                _context.SaveChanges();
            }
            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            var _book = _context.books.FirstOrDefault(n => n.Id == bookId);
            if(_book != null ) _context.books.Remove(_book);

        }
    }
}
