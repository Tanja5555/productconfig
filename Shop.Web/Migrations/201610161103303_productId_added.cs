namespace Shop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productId_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "ProductId");
            AddForeignKey("dbo.Orders", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropColumn("dbo.Orders", "ProductId");
        }
    }
}
