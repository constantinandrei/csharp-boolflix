namespace csharp_boolflix.Models
{
    public class Cast
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        List<Content>? Contents { get; set; }
    }
}
