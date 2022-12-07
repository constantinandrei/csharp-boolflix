using csharp_boolflix.Areas.Identity.Data;
using csharp_boolflix.Models;

namespace csharp_boolflix.Models.Repositories
{
    public class BoolflixDBRepository
    {
        private IdentityDataContext db;

        public BoolflixDBRepository(IdentityDataContext context)
        {
            db = context;
        }

        public List<Content> Get()
        {
            return db.Contents.ToList();
        }

        public List<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return db.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void Create(Content content, List<int> selectedCategories, string discriminator)
        {
            content.Categories = new List<Category>();
            foreach (int id in selectedCategories)
            {
                content.Categories.Add(GetCategory(id));
            }

            switch (discriminator)
            {
                case "Film":
                    Film film = new Film();
                    film.Categories = new List<Category>();
                    content.Categories.ForEach(c => film.Categories.Add(c));
                    film.Cover = content.Cover;
                    film.Title = content.Title;
                    db.Contents.Add(film);
                    break;
                case "Series":
                    Series series = new Series();
                    series.Categories = new List<Category>();
                    content.Categories.ForEach(c => series.Categories.Add(c));
                    series.Cover = content.Cover;
                    series.Title = content.Title;
                    db.Contents.Add(series);
                    break;
            }
            
            db.SaveChanges();
        }
    }
}
