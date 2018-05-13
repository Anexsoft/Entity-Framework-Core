using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Persistence.Database.Models;
using System.Linq;

namespace Services
{
    public class AlbumService
    {
        public void SetTotalOfSongs(int albumId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Database.ExecuteSqlCommand("USP_CountSongsByAlbum @p0", albumId);
            }
        }

        public void Add(Album model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Add(model);
                ctx.SaveChanges();
            }
        }

        public Album Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return (
                    ctx.Albums.Single(x => x.Id == id)
                );
            }
        }
    }
}
