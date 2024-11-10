using Microsoft.EntityFrameworkCore;
using System.Data;
using System;
using System.Diagnostics.SymbolStore;
using System.Net.Http.Headers;
using Trackster.Model;
using Trackster.Repository;

namespace Trackster.Repository
{
    public class TracksterContext : DbContext
    {   
        public TracksterContext(DbContextOptions<TracksterContext> dbContext)
          : base(dbContext) { }

        public DbSet<GenreMedia> GenreMedia { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<MediaPersonCrewRole> MediaPersonRole { get; set; }
        public DbSet<MediaStatistics> MediaStatistics { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<CrewRoles> CrewRoles { get; set; }
        public DbSet<StreamingServices> StreamingServices { get; set; }
        public DbSet<Tokens> Tokens { get; set; }
        public DbSet<TVShows> TVShows { get; set; }
        public DbSet<UserFavorites> UserFavorites { get; set; }
        public DbSet<UserFollow> UserFolllow { get; set; }
        public DbSet<UserPreferences> UserPreferences { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<UserSessions> UserSessions { get; set; }
        public DbSet<WatchlistMovie> WatchlistMovie { get; set; }
        public DbSet<WatchlistTVShow> WatchlistTVShow { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}   