namespace Shop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validation_option_choice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OptionChoices", "OptionChoiceName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OptionChoices", "OptionChoiceName", c => c.String());
        }
    }
}
