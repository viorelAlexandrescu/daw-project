using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using daw.Models;

namespace daw.Data {
    public class MyContext: DbContext {
        public MyContext(DbContextOptions < MyContext > options): base(options) {}

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity < Actor > ().ToTable("Actors");
            builder.Entity < Award > ().ToTable("Awards");
            builder.Entity < Cast > ().ToTable("Casts");
            builder.Entity < Genre > ().ToTable("Genres");
            builder.Entity < Language > ().ToTable("Languages");
            builder.Entity < MovieAward > ().ToTable("MovieAwards");
            builder.Entity < MovieGenre > ().ToTable("MovieGenres");
            builder.Entity < MovieLanguage > ().ToTable("MovieLanguages");
            builder.Entity < Movie > ().ToTable("Movies");
            builder.Entity < User > ().ToTable("Users");
            builder.Entity < Watchlist > ().ToTable("Watchlist");

            builder.Entity < Cast > ().HasKey(table => new {
                table.movieId, table.actorId
            });

            // builder.Entity < Cast > ()
            //     .HasOne(m => .actorId)
            //     .WithMany(m => m.movieId)
            //     .HasForeignKey(a => m.actorId);

            // modelBuilder.Entity < PersonClub > ()
            //     .HasOne(pc => pc.Club)
            //     .WithMany(c => c.PersonClubs)
            //     .HasForeignKey(pc => pc.ClubId);

            builder.Entity < MovieAward > ().HasKey(table => new {
                table.awardId, table.movieId
            });

            builder.Entity < MovieLanguage > ().HasKey(table => new {
                table.movieId, table.languageId
            });

            builder.Entity < MovieGenre > ().HasKey(table => new {
                table.genreId, table.movieId
            });

            builder.Entity < Watchlist > ().HasKey(table => new {
                table.userId, table.movieId
            });
        }

        public DbSet < Actor > Actors {
            get;
            set;
        }
        public DbSet < Award > Awards {
            get;
            set;
        }
        public DbSet < Genre > Genres {
            get;
            set;
        }
        public DbSet < Language > Languages {
            get;
            set;
        }
        public DbSet < Movie > Movies {
            get;
            set;
        }
        public DbSet < User > Users {
            get;
            set;
        }
    }
}