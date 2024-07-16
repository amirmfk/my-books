namespace WebApplication1.Data.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }

    public class AuthorsWithBooksVM 
    {
        public string FullName { get; set; }
        public List<string> BookTitles { get; set; }
    } 
}
