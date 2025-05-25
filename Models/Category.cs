namespace WebBanStore.Models
{
    public class Category
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Book>listBook { get; set; }
    }
}
