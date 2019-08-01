using System.Collections.Generic;

namespace MusicOrganizer.Models
{
    public class Genre
    {

        private static List<Genre> _instances = new List<Genre> { };
        public string Name { get; set; }
        public int Id { get; }
        public List<Artist> Artists { get; set; }

        public Genre(string genreName)
        {
            Name = genreName;
            _instances.Add(this);
            Id = _instances.Count;
            Artists = new List<Artist> { };
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

        public static List<Genre> GetAll()
        {
            return _instances;
        }

        public static Genre Find(int searchId)
        {
            return _instances[searchId - 1];
        }
        public void AddArtist(Artist artist)
        {
            Artists.Add(artist);
        }

    }
}