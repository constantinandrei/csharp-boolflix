namespace csharp_boolflix.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Cover { get; set; }
        public List<Cast>? Cast { get; set; }
        public List<Category>? Categories { get; set; }
    }
}
