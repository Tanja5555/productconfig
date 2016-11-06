namespace Shop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deliverydate_in_order : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DeliveryDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "DeliveryDate");
        }
    }
}
