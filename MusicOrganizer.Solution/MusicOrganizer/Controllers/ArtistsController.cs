using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
    public class ArtistsController : Controller
    {

        [HttpGet("/genres/{genreId}/artists/new")]
        public ActionResult New(int genreId)
        {
            Genre genre = Genre.Find(genreId);
            return View(genre);
        }

        [HttpGet("/genres/{genreId}/artists/{artistId}")]
        public ActionResult Show(int genreId, int artistId)
        {
            Artist artist = Artist.Find(artistId);
            Genre genre = Genre.Find(genreId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("artist", artist);
            model.Add("genre", genre);
            return View(model);
        }

        [HttpPost("/artists/delete")]
        public ActionResult DeleteAll()
        {
            Artist.ClearAll();
            return View();
        }

    }
}