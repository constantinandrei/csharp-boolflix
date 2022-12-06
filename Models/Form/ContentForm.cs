using csharp_boolflix.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace csharp_boolflix.Models.Form
{
    public class ContentForm
    {
        public Content Content { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        List<int>? SelectedCategories { get; set; }
    }
}
