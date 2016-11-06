namespace Shop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bool_not_mapped : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OptionChoices", "IsCheckedOptionChoice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OptionChoices", "IsCheckedOptionChoice", c => c.Boolean(nullable: false));
        }
    }
}
