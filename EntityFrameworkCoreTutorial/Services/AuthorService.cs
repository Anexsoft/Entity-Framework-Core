using Persistence.Database;
using Persistence.Database.Models;
using System.Linq;

namespace Services
{
    public class AuthorService
    {
        public void Add(Author model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Add(model);
                ctx.SaveChanges();
            }
        }

        public Author Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return (
                    ctx.Authors.Single(x => x.Id == id)
                );
            }
        }
    }
}
