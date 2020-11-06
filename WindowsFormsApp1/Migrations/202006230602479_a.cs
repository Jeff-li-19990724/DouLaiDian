namespace WindowsFormsApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foodinfoes",
                c => new
                    {
                        foodinfoID = c.Int(nullable: false, identity: true),
                        FoodID = c.Int(nullable: false),
                        Ingredients = c.String(),
                        Infodescribe = c.String(),
                    })
                .PrimaryKey(t => t.foodinfoID)
                .ForeignKey("dbo.FoodLists", t => t.FoodID, cascadeDelete: true)
                .Index(t => t.FoodID);
            
            CreateTable(
                "dbo.FoodLists",
                c => new
                    {
                        FoodID = c.Int(nullable: false),
                        FoodName = c.String(),
                        Price = c.Double(nullable: false),
                        FoodTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodID)
                .ForeignKey("dbo.FoodTypes", t => t.FoodTypeID, cascadeDelete: true)
                .Index(t => t.FoodTypeID);
            
            CreateTable(
                "dbo.FoodTypes",
                c => new
                    {
                        FoodTypeID = c.Int(nullable: false, identity: true),
                        FoodTypeName = c.String(),
                        describe = c.String(),
                    })
                .PrimaryKey(t => t.FoodTypeID);
            
            CreateTable(
                "dbo.FoodTables",
                c => new
                    {
                        TableID = c.Int(nullable: false, identity: true),
                        TableName = c.String(),
                        TableState = c.String(),
                        DateOut = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TableID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        phone = c.String(),
                        TotalParse = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ISOut = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.OrderLists",
                c => new
                    {
                        OrID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        foodname = c.String(),
                        price = c.Double(nullable: false),
                        num = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderLists", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Foodinfoes", "FoodID", "dbo.FoodLists");
            DropForeignKey("dbo.FoodLists", "FoodTypeID", "dbo.FoodTypes");
            DropIndex("dbo.OrderLists", new[] { "OrderID" });
            DropIndex("dbo.FoodLists", new[] { "FoodTypeID" });
            DropIndex("dbo.Foodinfoes", new[] { "FoodID" });
            DropTable("dbo.OrderLists");
            DropTable("dbo.Orders");
            DropTable("dbo.FoodTables");
            DropTable("dbo.FoodTypes");
            DropTable("dbo.FoodLists");
            DropTable("dbo.Foodinfoes");
        }
    }
}
