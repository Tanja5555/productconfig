namespace Shop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bool_not_null : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Delivered", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Delivered", c => c.Boolean());
        }
    }
}
