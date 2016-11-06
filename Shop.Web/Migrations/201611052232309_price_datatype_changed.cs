namespace Shop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class price_datatype_changed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OptionChoices", "OptionChoicePrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "ProductPrice", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.OptionChoices", "OptionChoicePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
