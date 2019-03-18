
namespace SleeperCell.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using SleeperCell.Controllers;
    using SleeperCell.Models;
    using System.Web;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<SleeperCell.Context.SleeperCellContext>
    {
       
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SleeperCell.Context.SleeperCellContext context)
        {
            var applicationUserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));


            if (!context.Users.Any(x => x.UserName == "admin"))
            {
                var newUser = new ApplicationUser()
                {
                    UserName = "admin",
                    Email = "admin@sleepercell.com"
                };
                var result = applicationUserManager.CreateAsync(newUser, "P@55w0rd").Result;

                context.Roles.Add(new IdentityRole { Name = "Admin" });
                context.Roles.Add(new IdentityRole { Name = "Manager" });
                context.Roles.Add(new IdentityRole { Name = "User" });
                context.Roles.Add(new IdentityRole { Name = "Supervisor" });
                context.SaveChanges();

                var roleResult = applicationUserManager.AddToRolesAsync(newUser.Id, "Admin").Result;
            }



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

        }
    }
}
