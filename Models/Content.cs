namespace csharp_boolflix.Models
{
    public abstract class Content
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Cover { get; set; }
        public List<Cast>? Cast { get; set; }
    }
}
