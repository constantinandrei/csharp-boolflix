namespace csharp_boolflix.Models
{
    public class Video
    {
        public int Id { get; set; } 
        public int ContentId { get; set; }
        public string LinkToVideo { get; set; }
        public int Length { get; set; }
        public Content? Content { get; set; }
    }
}
