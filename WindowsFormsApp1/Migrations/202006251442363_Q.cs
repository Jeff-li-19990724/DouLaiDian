namespace WindowsFormsApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Q : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodLists", "imageUrl", c => c.String());
            AddColumn("dbo.FoodLists", "introduce", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FoodLists", "introduce");
            DropColumn("dbo.FoodLists", "imageUrl");
        }
    }
}
