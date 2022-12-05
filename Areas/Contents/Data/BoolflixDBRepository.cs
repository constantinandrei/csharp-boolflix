﻿using csharp_boolflix.Areas.Identity.Data;
using csharp_boolflix.Models;

namespace csharp_boolflix.Areas.Contents.Data
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

        public void TestInsert()
        {
            Film film = new Film();
            film.Title = "Lo Squalo";
            film.Cover = "cover";
            db.Contents.Add(film);
            db.SaveChanges();
        }
    }
}