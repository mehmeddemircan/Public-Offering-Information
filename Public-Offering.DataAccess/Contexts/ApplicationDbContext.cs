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
        //Todo : Controllerlada admin olanlar area admin içine atılacak 
        // Todo : UserControllerlar yazılacak 
        public DbSet<User> Users { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<PublicOffer> PublicOffers { get; set; }
        public DbSet<Company> Companies { get; set; }


    }
}
