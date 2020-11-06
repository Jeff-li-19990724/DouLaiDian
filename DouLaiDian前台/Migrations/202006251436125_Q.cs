namespace DouLaiDian前台.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Q : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodLists",
                c => new
                    {
                        FoodID = c.Int(nullable: false),
                        FoodName = c.String(),
                        Price = c.Double(nullable: false),
                        FoodTypeID = c.Int(nullable: false),
                        imageUrl = c.String(),
                        introduce = c.String(),
                    })
                .PrimaryKey(t => t.FoodID)
                .ForeignKey("dbo.FoodTypes", t => t.FoodTypeID, cascadeDelete: true)
                .Index(t => t.FoodTypeID);
        }
        
        public override void Down()
        {

            DropForeignKey("dbo.FoodLists", "FoodTypeID", "dbo.FoodTypes");

            DropTable("dbo.FoodLists");
         
        }
    }
}
