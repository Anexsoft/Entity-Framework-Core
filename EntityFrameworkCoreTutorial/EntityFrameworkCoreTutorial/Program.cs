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
            FourthExample();
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

        // Validar restricción
        static void SecondExample()
        {
            var songService = new SongService();

            songService.Add(new Song
            {
                Description = "Es una canción escrita por el bajista Steve Harris publicado el 20 de junio de 1983",
                Title = "The Trooper",
                Duration = TimeSpan.FromSeconds(250),
                AlbumId = 1
            });
        }

        // Métodos crud
        static void ThirdExample()
        {
            var songService = new SongService();

            var newEntry = new Song
            {
                Description = "Excelente canción de Metallica",
                Title = "Nothing Else Matter",
                Duration = TimeSpan.FromSeconds(350),
                AlbumId = 2
            };

            songService.Add(newEntry);

            newEntry.Title = "One";
            songService.Update(newEntry);

            songService.Delete(newEntry.Id);
        }

        // Select de varias tablas
        static void FourthExample()
        {
            var songService = new SongService();

            var result = songService.GetAll3();
        }
    }
}
