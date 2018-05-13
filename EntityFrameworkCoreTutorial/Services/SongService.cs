using Persistence.Database;
using Persistence.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class SongService
    {
        public void Add(Song model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Add(model);
                ctx.SaveChanges();
            }
        }

        public void Update(Song model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entryOriginal = ctx.Songs.Single(x => x.Id == model.Id);

                entryOriginal.Title = model.Title;
                entryOriginal.Description = model.Description;
                entryOriginal.Duration = model.Duration;

                ctx.Update(entryOriginal);
                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entryOriginal = ctx.Songs.Single(x => x.Id == id);
                ctx.Remove(entryOriginal);
                ctx.SaveChanges();
            }
        }

        public Song Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return (
                    ctx.Songs.Single(x => x.Id == id)
                );
            }
        }

        public List<Song> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return (
                    ctx.Songs.OrderBy(x => x.Title)
                             .ThenBy(x => x.Album.Title)
                             .ToList()
                );
            }
        }
    }
}
