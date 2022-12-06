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

        public void CreateFilm(Content content)
        {
            Film film = new Film();
            film.Title = content.Title;
            film.Cover = content.Cover;

            db.Contents.Add(film);
            db.SaveChanges();
        }

        public void CreateSeries(Content content)
        {
            Series series = new Series();
            series.Title = content.Title;
            series.Cover = content.Cover;

            db.Contents.Add(series);
            db.SaveChanges();
        }
    }
}
