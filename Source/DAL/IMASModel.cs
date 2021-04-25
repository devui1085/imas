using System.Diagnostics;
using IMAS.Model.Domain.Core;

namespace IMAS.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IMASModel : DbContext
    {
        public IMASModel()
            : base("name=IMASConnectionString")
        {
            Database.SetInitializer<IMASModel>(new CreateDatabaseIfNotExists<IMASModel>());
            this.Configuration.LazyLoadingEnabled = false;
            EnableLog();
        }

        private void EnableLog()
        {
            this.Database.Log = msg => Debug.WriteLine($"SQL: {msg}");
        }
        public virtual DbSet<Advertisment> Advertisments { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<AdvertismentVisit> AdvertismentVisits { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogLink> BlogLinks { get; set; }
        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<CncLathe> CncLathes { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<EducationalResume> EducationalResumes { get; set; }
        public virtual DbSet<ExceptionLog> ExceptionLogs { get; set; }
        public virtual DbSet<FeaturedContent> FeaturedContents { get; set; }
        public virtual DbSet<Follow> Follows { get; set; }
        public virtual DbSet<ForbiddenIdentifier> ForbiddenIdentifiers { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobResume> JobResumes { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Machinery> Machineries { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<NormalLathe> NormalLathes { get; set; }
        public virtual DbSet<NormalCarousel> NormalCarousels { get; set; }
        public virtual DbSet<FlatStone> FlatStones { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<Reference> References { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<UniversityField> UniversityFields { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Advertisment>()
            //    .HasOptional(e => e.Machinery)
            //    .WithRequired(e => e.Advertisment)
            //    .WillCascadeOnDelete();

            modelBuilder.Entity<Blog>()
                .HasMany(e => e.Links)
                .WithRequired(e => e.Blog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Content>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Contents)
                .Map(m => m.ToTable("ContentTag", "core").MapLeftKey("ContentId").MapRightKey("TagId"));

            modelBuilder.Entity<Follow>()
                .Property(e => e.CreateDate)
                .HasPrecision(2);

            modelBuilder.Entity<Media>()
                .Property(e => e.CreateDate)
                .HasPrecision(2);

            modelBuilder.Entity<Membership>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<Message>()
                .Property(e => e.CreateDate)
                .HasPrecision(2);

            //modelBuilder.Entity<Publication>()
            //    .HasOptional(e => e.Blog)
            //    .WithRequired(e => e.Publication);

            //modelBuilder.Entity<Publication>()
            //    .HasOptional(e => e.Channel)
            //    .WithRequired(e => e.Publication);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UserRole", "core").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<User>()
                .HasMany(e => e.Advertisments)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Advertisment>()
                .HasMany(e => e.Pictures)
                .WithRequired(e => e.Advertisment)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Advertisment>()
               .HasMany(e => e.AdvertismentVisits)
               .WithRequired(e => e.Advertisment)
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<Advertisment>()
                .Property(x => x.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Sender)
                .HasForeignKey(e => e.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Contents)
                .WithRequired(e => e.Author)
                .HasForeignKey(e => e.AuthorId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Follows)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.FollowedId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Follows1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.FollowerId);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Membership)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<User>()
              .HasMany(e => e.Profiles)
              .WithRequired(e => e.User)
              .WillCascadeOnDelete(true);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Receiver)
                .HasForeignKey(e => e.ReceiverId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages1)
                .WithRequired(e => e.Sender)
                .HasForeignKey(e => e.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Notifications)
                .WithRequired(e => e.Receiver)
                .HasForeignKey(e => e.ReceiverId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Notifications1)
                .WithOptional(e => e.Subject)
                .HasForeignKey(e => e.SubjectId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Publications)
                .WithRequired(e => e.Creator)
                .HasForeignKey(e => e.CreatorId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Rates)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
