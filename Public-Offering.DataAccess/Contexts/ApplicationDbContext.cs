using Microsoft.EntityFrameworkCore;
using Public_Offering.Core.Entities.Concrete.Auth;
using Public_Offering.Types.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.DataAccess.Contexts
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=PublicOffering;Trusted_Connection=true");


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCommentLike>()
                .HasKey(uc => new { uc.UserId, uc.CommentId });


            modelBuilder.Entity<UserCommentLike>()
                .HasOne(uc => uc.Comment)
                .WithMany(c => c.LikedByUsers)
                .HasForeignKey(uc => uc.CommentId)
                .OnDelete(DeleteBehavior.Restrict); // Specify the cascade behavior here

            // Your other entity configurations...

            base.OnModelCreating(modelBuilder);
        }

        //Todo : Controllerlada admin olanlar area admin içine atılacak 
        // Todo : UserControllerlar yazılacak 
        public DbSet<User> Users { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<PublicOffer> PublicOffers { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserCommentLike> UserCommentLikes { get; set; }


    }
}
