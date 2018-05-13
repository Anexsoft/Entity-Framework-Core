using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }

        public List<Song> Songs { get; set; }

        public DateTime? PublishedAt { get; set; }

        public bool Deleted { get; set; }
    }
}
