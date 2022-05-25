using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserHouseRole.Models;

namespace UserHouseRole.Data
{

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SaleHouse> SaleHouse { get; set; }
        public DbSet<RentHouse> RentHouse { get; set; }
        public DbSet<CreditHouse> CreditHouse { get; set; }
    }
}
