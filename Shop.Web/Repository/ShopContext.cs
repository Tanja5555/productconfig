namespace Shop.Web.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using TanLeonaShop.Domain.Models;
    public class ShopContext : IdentityDbContext<AppUser>
    {
        // Your context has been configured to use a 'ShopContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Shop.Web.Models.ShopContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ShopContext' 
        // connection string in the application configuration file.
        public ShopContext() : base("name=ShopContext")
        {
            
        }

        public DbSet<Product> dbProducts { get; set; }
        public DbSet<Order> dbOrders { get; set; }
        public DbSet<Option> dbOptions { get; set; }
        public DbSet<OptionChoice> dbOptionChoices { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}