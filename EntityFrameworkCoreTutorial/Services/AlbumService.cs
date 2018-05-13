using Persistence.Database;
using Persistence.Database.Models;
using System.Linq;

namespace Services
{
    public class AlbumService
    {
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
