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
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId,
            };
            _context.books.Add(_book);
            _context.SaveChanges();

        }

        public void AddBookWithAuthors(BookVM book)
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
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId,
            };
            _context.books.Add(_book);
            _context.SaveChanges();

            foreach(var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };

                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();

            }

        }

        public IEnumerable<Book> GetBooks() => _context.books;

        public BookWithAuthorNamesVM GetBookById(int id)
        {
            var _book = _context.books.Where(b => b.Id == id).Select(s => new BookWithAuthorNamesVM()
            {
                Title = s.Title,
                Description = s.Description,
                IsRead = s.IsRead,
                DateRead = s.DateRead,
                Rate = s.Rate,
                CoverUrl = s.CoverUrl,
                Genre = s.Genre,
                PublisherName = s.Publisher.Name,
                AuthorNames = s.Book_Authors.Select(n => n.Author.FullName).ToList()

            }).FirstOrDefault();
            return _book;
        }

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
                _book.DateAdded = DateTime.Now;
                _book.PublisherId = book.PublisherId;
                _context.SaveChanges();
            }
            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            var _book = _context.books.FirstOrDefault(n => n.Id == bookId);
            if(_book != null )
            {
                _context.books.Remove(_book);
                _context.SaveChanges();
            } 
        }
    }
}
