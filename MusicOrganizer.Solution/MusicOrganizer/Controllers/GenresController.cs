using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
    public class GenresController : Controller
    {
        [HttpGet("/genres")]
        public ActionResult Index()
        {
            List<Genre> allGenres = Genre.GetAll();
            return View(allGenres);
        }
        [HttpGet("/genres/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/genres")]
        public ActionResult Create(string genreName)
        {
            Genre newGenre = new Genre(genreName);
            return RedirectToAction("Index");
        }

        [HttpGet("/genres/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Genre selectedGenre = Genre.Find(id);
            List<Artist> genreArtists = selectedGenre.Artists;
            model.Add("genre", selectedGenre);
            model.Add("artists", genreArtists);
            return View(model);
        }

        [HttpPost("/genres/{genreId}/artists")]
        public ActionResult Create(int genreId, string artistDescription)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Genre foundGenre = Genre.Find(genreId);
            Artist newArtist = new Artist(artistDescription);
            foundGenre.AddArtist(newArtist);
            List<Artist> genreArtists = foundGenre.Artists;
            model.Add("artists", genreArtists);
            model.Add("genre", foundGenre);
            return View("Show", model);
        }

    }
}