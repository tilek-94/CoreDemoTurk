using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-H4I97P3\\SQLSERVER; Database=CoreBlogDb; Persist Security Info=false; User ID='sa'; Password='sa'; MultipleActiveResultSets=True; Trusted_Connection=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasOne(x=>x.HomeTeam)
                .WithMany(y=>y.HomeMatches)
                .HasForeignKey(z=>z.HomeTeamID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Match>()
               .HasOne(x => x.GuestTeam)
               .WithMany(y => y.AwayMatches)
               .HasForeignKey(z => z.GuestTeamID)
               .OnDelete(DeleteBehavior.ClientSetNull);
           
            modelBuilder.Entity<Message2>()
           .HasOne(x => x.SenderUser)
           .WithMany(y => y.WriterSender)
           .HasForeignKey(z => z.SenderID)
           .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
           .HasOne(x => x.ReceiverUser)
           .WithMany(y => y.WriterReciver)
           .HasForeignKey(z => z.ReceiverID)
           .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetter { get; set; }
        public DbSet<BlogRayting> BlogRayting { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Message2> Message2s { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
       
    }
}
