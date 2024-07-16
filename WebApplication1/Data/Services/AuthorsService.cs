using WebApplication1.Data.Models;
using WebApplication1.Data.ViewModels;

namespace WebApplication1.Data.Services
{
    public class AuthorsService
    {
        private readonly AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM book)
        {
            var _author = new Author()
            {
                FullName = book.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorsWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorsWithBooksVM()
            {
                FullName = n.FullName,
                BookTitles = n.Book_Authors.Select(n =>n.Book.Title).ToList()
            }).FirstOrDefault();

            return _author;
        }
    }
}
