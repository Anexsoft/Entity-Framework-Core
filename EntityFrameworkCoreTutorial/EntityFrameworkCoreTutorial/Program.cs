using Persistence.Database;
using Persistence.Database.Models;
using Services;
using System;

namespace EntityFrameworkCoreTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            FirtExample();
        }

        // Primer ejemplo
        static void FirtExample()
        {
            var authorService = new AuthorService();
            var albumService = new AlbumService();
            var songService = new SongService();

            var album = new Album
            {
                Title = "The Trooper",
                Author = new Author
                {
                    Name = "Iron Maiden"
                }
            };

            albumService.Add(album);

            songService.Add(new Song
            {
                Description = "Es una canción escrita por el bajista Steve Harris publicado el 20 de junio de 1983",
                Title = "The Trooper",
                Duration = TimeSpan.FromSeconds(250),
                AlbumId = album.Id
            });
        }
    }
}
