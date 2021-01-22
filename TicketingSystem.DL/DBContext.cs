using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Assessment.DL.Entities;
using Assessment.Shared.Models;

namespace Assessment.DL
{
    //DBContext inherits from the EF Core IdentityDbContext
    //Identity Membership from EF Core Identity
    public class DBContext: IdentityDbContext<IdentityUser>
    {
        //Passing the instance of the DbContext Options,
        //The options are then passed to the Base type
        public DBContext(DbContextOptions<DBContext> options):base(options)
        {

        }

        //Table Entities
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<GetInTouch> GetInTouch { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }
        public DbSet<IssueSeverity> IssueSeverity { get; set; }
        public DbSet<ResolutionStatus> ResolutionStatus { get; set; }
        public DbSet<ResolutionSteps> ResolutionSteps { get; set; }
    }
}
