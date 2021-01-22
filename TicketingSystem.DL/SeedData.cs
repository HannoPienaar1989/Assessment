using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.DL.Entities;

namespace Assessment.DL
{
    public class SeedData
    {
        public static void Seed(DBContext context)
        {
            //Seed Lookup Data
            if (!context.IssueTypes.Any())
            {
                context.AddRange(
                        new IssueType { Type = "Technical", CreatedAt = DateTime.Now },
                        new IssueType { Type = "Network", CreatedAt = DateTime.Now },
                        new IssueType { Type = "Software", CreatedAt = DateTime.Now },
                        new IssueType { Type = "Hardware", CreatedAt = DateTime.Now }
                    );
                context.SaveChanges();
            }

            if (!context.IssueSeverity.Any())
            {
                context.AddRange(
                        new IssueSeverity { Severity = "High", CreatedAt = DateTime.Now },
                        new IssueSeverity { Severity = "Medium", CreatedAt = DateTime.Now },
                        new IssueSeverity { Severity = "Low", CreatedAt = DateTime.Now }
                    );
                context.SaveChanges();
            }

            if (!context.ResolutionStatus.Any())
            {
                context.AddRange(
                        new ResolutionStatus { Status = "Logged", CreatedAt = DateTime.Now },
                        new ResolutionStatus { Status = "Active", CreatedAt = DateTime.Now },
                        new ResolutionStatus { Status = "Resolved", CreatedAt = DateTime.Now },
                        new ResolutionStatus { Status = "Closed", CreatedAt = DateTime.Now }
                    );
                context.SaveChanges();

            }

            if (context.Users.FirstOrDefault(r => r.UserName == "admin@Assessment.co.za") == null)
            {
                //Hashed Password: P@ssw0rd!
                var technician = new IdentityUser
                {
                    UserName = "admin@Assessment.co.za",
                    Email = "admin@Assessment.co.za",
                    NormalizedUserName = "ADMIN@Assessment.CO.ZA",
                    NormalizedEmail = "ADMIN@Assessment.CO.ZA",
                    PasswordHash = "AQAAAAEAACcQAAAAEOY6eQ0dx0McHkCGgqt2L40604gd63d8LeaYvF8O+qq+DeJpO+FnWlyWEJUGVOO2dQ==",
                    SecurityStamp = "O5DZARM26USTWJ7UV7LMBDT2KSL7KM37"
                };
                context.Add(technician);
                context.SaveChanges();

                var role = context.Roles.FirstOrDefault(r => r.Name == "Technician");
                if (role == null)
                {
                    role = new IdentityRole { Name = "Technician", NormalizedName = "TECHNICIAN" };
                    context.Add(role);
                    context.SaveChanges();
                }

                context.Add(new IdentityRoleClaim<string>() { RoleId = role.Id, ClaimType = "Permission", ClaimValue = "ManageTickets" });
                context.UserRoles.Add(new IdentityUserRole<string>() { RoleId = role.Id, UserId = technician.Id});
                context.SaveChanges();

            }
        }
        
    }
}
