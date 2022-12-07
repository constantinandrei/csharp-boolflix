using csharp_boolflix.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace csharp_boolflix.Models.Form
{
    public class ContentForm
    {
        public Content Content { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        public List<int>? SelectedCategories { get; set; }
        public string Discriminator { get; set; }
        public Video? Video { get; set; }
        public ContentForm()
        {
            Categories = new List<SelectListItem>();
        }
    }
}
