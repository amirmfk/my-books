using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Net;
using System.Threading;
using WebApplication1.Data.Models;
using WebApplication1.Data.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Data.Services
{
    public class BooksService
    {
        private readonly AppDbContext _context;
        public BooksService(AppDbContext context)
        {

            _context = context;

        }
        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId =  _book.Id,
                    AuthorId = id
                };

                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }

        public  List<Book> GetAllBooks()
        {
            var books = _context.Books.ToList();
            return books;
        }

        public BookWithAuthorsVM GetBookById(int bookId)
        {
            var _bookWithAuthors = _context.Books.Where(n => n.Id ==bookId).Select(book => new BookWithAuthorsVM()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault(); 
            return _bookWithAuthors;
        }

        public Book UpdateBookById(int id , BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == id);

            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;
                _context.SaveChanges();
            }
            return _book;
        }

        public void DeleteBookById(int id)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == id);
            if( _book != null)
            {
                _context.Books.Remove( _book );
                _context.SaveChanges();
            }
        }

    }
}
