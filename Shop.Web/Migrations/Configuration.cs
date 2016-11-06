namespace Shop.Web.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TanLeonaShop.Domain.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Shop.Web.Models.ShopContext>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(Shop.Web.Models.ShopContext context)
    {
        //Seed database with an admin user and role.
        if (!context.Roles.Any(r => r.Name == "admins"))
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var role = new IdentityRole { Name = "admins" };
            roleManager.Create(role);
        }
        if (!context.Users.Any(u => u.UserName == "admin"))
        {
            var userStore = new UserStore<AppUser>(context);
            var userManager = new UserManager<AppUser>(userStore);
            var user = new AppUser
            {
                UserName = "admin",
                Firstname = "Tanja",
                Email = "tanja.v.leonova@gmail.com",
            };
            userManager.Create(user, "Password");
            userManager.AddToRole(user.Id, "admins");
        }


            if (!context.Roles.Any(r => r.Name == "users"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "users" };
                roleManager.Create(role);
            }
            if (!context.Users.Any(u => u.UserName == "testUser"))
            {
                var userStore = new UserStore<AppUser>(context);
                var userManager = new UserManager<AppUser>(userStore);
                var user = new AppUser
                {
                    UserName = "testUser",
                    Firstname = "Lena",
                    Email = "lena@gmail.com",
                };
                userManager.Create(user, "lenaspassword");
                userManager.AddToRole(user.Id, "users");
            }

            var products = new List<Product>
            {
                new Product { Id = 1, ProductName = "Picture Frame",  ProductPrice = 100, ProductDeliveryDate = DateTime.Parse("2016-11-01"), ProductImage = " http://www.configuremyproduct.com/wp-content/uploads/2014/11/picture-frame1.jpg", ProductCode = "PF"},
                new Product { Id = 2, ProductName = "Cupboard",  ProductPrice = 200, ProductDeliveryDate = DateTime.Parse("2016-11-01"), ProductImage = "http://www.configuremyproduct.com/wp-content/uploads/2014/11/cupboard-hq.jpg", ProductCode = "CB" }
            };
        products.ForEach(s => context.dbProducts.AddOrUpdate(p => p.Id, s));
        context.SaveChanges();

        var options = new List<Option>
            {
                new Option { Id = 1, OptionName = "Width", ProductId = 1 },
                new Option { Id = 2, OptionName = "Length", ProductId = 1 },
                new Option { Id = 3, OptionName = "Color", ProductId = 1 },
                new Option { Id = 4, OptionName = "Glazing", ProductId = 1 },
                new Option { Id = 5, OptionName = "Width", ProductId = 2 },
                new Option { Id = 6, OptionName = "Length", ProductId = 2 },
                new Option { Id = 7, OptionName = "Depth", ProductId = 2 },
                new Option { Id = 8, OptionName = "Material", ProductId = 2 },
                new Option { Id = 9, OptionName = "Accessories", ProductId = 2 }
            };
        options.ForEach(s => context.dbOptions.AddOrUpdate(o => o.Id, s));
        context.SaveChanges();


        var optionChoices = new List<OptionChoice>
            {
                new OptionChoice { Id = 1, OptionId = 1, OptionChoiceName = "w10",  OptionChoiceCode = "w10",   OptionChoicePrice = 10, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-20")},
                new OptionChoice { Id = 2, OptionId = 1, OptionChoiceName = "w20",  OptionChoiceCode = "w20",   OptionChoicePrice = 20, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-21")},
                new OptionChoice { Id = 3, OptionId = 1, OptionChoiceName = "w30",  OptionChoiceCode = "w30",   OptionChoicePrice = 30, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-25")},
                new OptionChoice { Id = 4, OptionId = 2, OptionChoiceName = "l20",  OptionChoiceCode = "l20",   OptionChoicePrice = 20, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-20")},
                new OptionChoice { Id = 5, OptionId = 2, OptionChoiceName = "l30",  OptionChoiceCode = "l30",   OptionChoicePrice = 30, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-20")},
                new OptionChoice { Id = 6, OptionId = 2, OptionChoiceName = "l40",  OptionChoiceCode = "l40",   OptionChoicePrice = 40, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-22")},
                new OptionChoice { Id = 7, OptionId = 3, OptionChoiceName = "white",  OptionChoiceCode = "whi",   OptionChoicePrice = 10, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-20")},
                new OptionChoice { Id = 8, OptionId = 3, OptionChoiceName = "black",  OptionChoiceCode = "bla",   OptionChoicePrice = 20, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-23")},
                new OptionChoice { Id = 9, OptionId = 3, OptionChoiceName = "gray",  OptionChoiceCode = "gra",   OptionChoicePrice = 30, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-25")},
                new OptionChoice { Id = 10, OptionId = 4, OptionChoiceName = "acrylic", OptionChoiceCode = "acry",   OptionChoicePrice = 10, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-22")},
                new OptionChoice { Id = 11, OptionId = 4, OptionChoiceName = "glass",  OptionChoiceCode = "gla",   OptionChoicePrice = 20, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-21")},
                new OptionChoice { Id = 12, OptionId = 5, OptionChoiceName = "w500",  OptionChoiceCode = "w500",   OptionChoicePrice = 100, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-21")},
                new OptionChoice { Id = 13, OptionId = 5, OptionChoiceName = "w600",  OptionChoiceCode = "w600",   OptionChoicePrice = 150, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-21")},
                new OptionChoice { Id = 14, OptionId = 6, OptionChoiceName = "l700",  OptionChoiceCode = "l700",   OptionChoicePrice = 200, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-25")},
                new OptionChoice { Id = 15, OptionId = 6, OptionChoiceName = "l800",  OptionChoiceCode = "l700",   OptionChoicePrice = 250, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-21")},
                new OptionChoice { Id = 16, OptionId = 7, OptionChoiceName = "d100",  OptionChoiceCode = "d100",   OptionChoicePrice = 50, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-21")},
                new OptionChoice { Id = 17, OptionId = 7, OptionChoiceName = "d150",  OptionChoiceCode = "d150",   OptionChoicePrice = 100, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-21")},
                new OptionChoice { Id = 18, OptionId = 8, OptionChoiceName = "maple",  OptionChoiceCode = "mapl",   OptionChoicePrice = 50, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-20")},
                new OptionChoice { Id = 19, OptionId = 8, OptionChoiceName = "beech",  OptionChoiceCode = "be",   OptionChoicePrice = 60, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-21")},
                new OptionChoice { Id = 20, OptionId = 8, OptionChoiceName = "mahogany",  OptionChoiceCode = "maho",   OptionChoicePrice = 70, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-21")},
                new OptionChoice { Id = 21, OptionId = 9, OptionChoiceName = "shaker knob chrome",  OptionChoiceCode = "shkch",   OptionChoicePrice = 50, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-21")},
                new OptionChoice { Id = 22, OptionId = 9, OptionChoiceName = "round oak",  OptionChoiceCode = "rooa",   OptionChoicePrice = 60, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-21")},
                new OptionChoice { Id = 23, OptionId = 9, OptionChoiceName = "handle chrome",  OptionChoiceCode = "hanch",   OptionChoicePrice = 70, OptionChoiceDeliveryDate = DateTime.Parse("2016-11-25")}
            };
        optionChoices.ForEach(s => context.dbOptionChoices.AddOrUpdate(och => och.Id, s));
        context.SaveChanges();
    }
}
}
