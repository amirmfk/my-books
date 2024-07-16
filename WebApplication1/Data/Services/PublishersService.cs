using System.Text.RegularExpressions;
using WebApplication1.Data.Models;
using WebApplication1.Data.ViewModels;
using WebApplication1.Exceptions;

namespace WebApplication1.Data.Services
{
    public class PublishersService
    {
        private readonly AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public Publisher AddPublisher(PublisherVM publisher)
        {
            if (StringStartWithNumber(publisher.FullName)) 
            {
                throw new PublisherNameException("Name starts with number", publisher.FullName);
            }
            var _publisher = new Publisher()
            {
                Name = publisher.FullName
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }
        public Publisher GetPublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            return _publisher;
        }

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId).Select(n => new PublisherWithBooksAndAuthorsVM()
            {
                Name = n.Name,
                BookAuthors = n.Books.Select(n => new BookAuthorVM()
                {
                    BookName = n.Title,
                    BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                }).ToList()
            }).FirstOrDefault();

            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"Publisher with id {id} does not exist.");
            }
        }

        private bool StringStartWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));
        
    }
}
