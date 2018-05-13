using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Persistence.Database.Models;
using Services.Dto;
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

        public List<SongDto> GetAll2()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return GetSongDtoBaseQuery(ctx).ToList();
            }
        }

        public List<SongDto> GetAll3()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return GetSongDtoBaseQuery(ctx).OrderBy(x => x.Author).ToList();
            }
        }

        public List<SongDto> GetAll4()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return GetSongDtoBaseQuery(ctx).OrderBy(x => x.Duration).ToList();
            }
        }

        public IQueryable<SongDto> GetSongDtoBaseQuery(ApplicationDbContext ctx)
        {
            return (
                from s in ctx.Songs
                join a in ctx.Albums on s.AlbumId equals a.Id
                join at in ctx.Authors on a.AuthorId equals at.Id
                select new SongDto
                {
                    Album = a.Title,
                    Author = at.Name,
                    Duration = s.Duration,
                    Title = s.Title,
                    SongId = s.Id
                }
            ).AsQueryable();
        }

        public List<Song> GetFromProcedure()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Songs
                          .FromSql("USP_GetSongs").ToList();
            }
        }

        public Song GetFromProcedure(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Songs.FromSql("USP_GetSongs @p0", id).Single();
            }
        }
    }
}
