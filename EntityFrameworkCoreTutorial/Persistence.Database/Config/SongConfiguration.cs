using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class SongConfiguration
    {
        public SongConfiguration(EntityTypeBuilder<Song> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.Description).HasMaxLength(200).IsRequired();
        }
    }
}
