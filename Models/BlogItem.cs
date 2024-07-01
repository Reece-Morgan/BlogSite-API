namespace BlogSite_API.Models
{
    public class BlogItem
    {
        public int Id {  get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public int ReadLength { get; set; }
    }
}
