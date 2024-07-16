using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebApplication1.Exceptions
{
    [Serializable]
    public class PublisherNameException:Exception
    {
        public string PublisherName { get; set; }

        public PublisherNameException()
        {

        }

        public PublisherNameException(string message) : base(message)
        {

        }

        public PublisherNameException(string message, Exception inner) : base(message, inner)
        {

        }

        public PublisherNameException(string message, string publisherName): this(message)
        {
            publisherName = PublisherName;
        }
    }
}
