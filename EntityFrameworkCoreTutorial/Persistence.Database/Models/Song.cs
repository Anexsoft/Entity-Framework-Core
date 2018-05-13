using System;

namespace Persistence.Database.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }

        public Album Album { get; set; }
        public int AlbumId { get; set; }
    }
}
