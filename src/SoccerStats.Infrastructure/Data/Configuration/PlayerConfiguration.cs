using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerStats.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Infrastructure.Data.Configuration;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasIndex(c => c.UserName)
            .IsUnique();

        builder.HasIndex(c => new { c.FirstName, c.LastName });
        
        builder.Property(c => c.FirstName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(c => c.LastName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(c => c.UserName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(c => c.BirthDay)
            .IsRequired();

        builder.HasOne(o => o.Team)
            .WithMany(c => c.Players)
            .HasForeignKey(o => o.TeamId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        // seed data
        builder.HasData(
            new Player()
            {
                Id = 1,
                FirstName = "Tony",
                LastName = "Pane",
                UserName = "tpane3",
                BirthDay = new DateTime(1985, 5, 1),
                TeamId = 1
            });
    }
}

