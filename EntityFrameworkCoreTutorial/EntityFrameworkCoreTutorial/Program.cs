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
            SixthExample();
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
                Description = "The Unforgiven es el nombre que se le da a las tres canciones (power ballad) homónimas de thrash metal, que han sido incluidas en los álbumes Metallica.",
                Title = "The unforgiven",
                Duration = TimeSpan.FromSeconds(250),
                AlbumId = 2
            });

            songService.Add(new Song
            {
                Description = "Don't Tread on Me es la sexta canción del quinto álbum de Metallica, titulado Metallica, aunque también puede ser conocido como The Black Album.",
                Title = "Don't Tread on Me",
                Duration = TimeSpan.FromSeconds(250),
                AlbumId = 2
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

        // From store procedures
        static void FifthExample()
        {
            var songService = new SongService();

            var result = songService.GetFromProcedure();
            var result2 = songService.GetFromProcedure(2);
        }

        // execute USP
        static void SixthExample()
        {
            var albumService = new AlbumService();

            albumService.SetTotalOfSongs(2);
            var album = albumService.Get(2);
        }
    }
}
