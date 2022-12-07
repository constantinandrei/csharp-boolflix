using csharp_boolflix.Models;
using csharp_boolflix.Models.Form;
using csharp_boolflix.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    [Authorize]
    public class ContentController : Controller
    {
        private BoolflixDBRepository repository;
        private ContentFormRepository formData;
        public ContentController(BoolflixDBRepository repository, ContentFormRepository formData)
        {
            this.repository = repository;
            this.formData = formData;
        }

        public IActionResult Index()
        {
            return View(repository.Get());
        }

        public IActionResult Create(string discriminator)
        {
            return View(formData.Create(discriminator));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContentForm form)
        {
            if (!ModelState.IsValid)
                return View(form);
            repository.Create(form.Content, form.SelectedCategories, form.Discriminator);
            return RedirectToAction("Index");
        }
    }
}
