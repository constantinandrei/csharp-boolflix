﻿using csharp_boolflix.Models.Form;
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
            return View();
        }

        public IActionResult Create()
        {
            
            return View();
        }
    }
}
