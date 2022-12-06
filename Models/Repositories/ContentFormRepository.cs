using csharp_boolflix.Areas.Identity.Data;
using csharp_boolflix.Models.Form;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;

namespace csharp_boolflix.Models.Repositories
{
    public class ContentFormRepository
    {
        public BoolflixDBRepository repository;

        public ContentFormRepository(BoolflixDBRepository repository)
        {
            this.repository = repository;
        }
        public ContentForm Create(string discriminator)
        {
            ContentForm form = new ContentForm();
            form.Discriminator = discriminator;
            List<Category> categories = repository.GetCategories();
            foreach (Category category in categories)
            {
                form.Categories.Add(new SelectListItem(category.Name, category.Id.ToString()));
            }

            switch (discriminator)
            {
                case "Film":
                    form.Content = new Film();
                    
                    break;
                case "Series":
                    form.Content = new Series();
                    break;
            }

            return form;
        }
    }
}
