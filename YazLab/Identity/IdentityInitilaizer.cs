using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace YazLab.Identity
{
    public class IdentityInitilaizer : DropCreateDatabaseIfModelChanges<IdentityContext>
    {
        protected override void Seed(IdentityContext context)
        {
            //Roller
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Description = "admin rolu" };
                manager.Create(role);
            }

            //Roller
            if (!context.Roles.Any(i => i.Name == "ogrenci"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "ogrenci", Description = "ogrenci rolu" };
                manager.Create(role);
            }

            if (!context.Roles.Any(i => i.Name == "ogretmen"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "ogretmen", Description = "ogretmen rolu" };
                manager.Create(role);
            }

            //if (!context.Users.Any(i => i.Name == "batuhanaral"))
            //{
            //    var store = new UserStore<ApplicationUser>(context);
            //    var manager = new UserManager<ApplicationUser>(store);
            //    var user = new ApplicationUser() { Name = "batuhan", Surname = "aral", UserName = "batuhanaral", Email = "batuhanaral3@gmail.com" };
            //    manager.Create(user, "1234567");
            //    manager.AddToRole(user.Id, "admin");

            //}

            //if (!context.Users.Any(i => i.Name == "oguzcetinkaya"))
            //{
            //    var store = new UserStore<ApplicationUser>(context);
            //    var manager = new UserManager<ApplicationUser>(store);
            //    var user = new ApplicationUser() { Name = "oguz", Surname = "cetinkaya", UserName = "oguzcetinkaya", Email = "huseyinoguzc@gmail.com" };
            //    manager.Create(user, "1234567");
            //    manager.AddToRole(user.Id, "ogrenci");

            //}



            base.Seed(context);
        }
    }
}