using Persistence.Database;
using Persistence.Database.Models;
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

        public Song Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return (
                    ctx.Songs.Single(x => x.Id == id)
                );
            }
        }
    }
}
