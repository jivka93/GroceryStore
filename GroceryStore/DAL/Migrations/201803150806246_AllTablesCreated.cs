namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllTablesCreated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "User_Id", "dbo.Users");
            DropIndex("dbo.Addresses", new[] { "User_Id" });
            RenameColumn(table: "dbo.Addresses", name: "User_Id", newName: "UserId");
            CreateTable(
                "dbo.BankCards",
                c => new
                    {
                        Number = c.String(nullable: false, maxLength: 128),
                        ExpirationDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Number, t.ExpirationDate })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Status = c.String(nullable: false, maxLength: 10),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Order_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Order_Id);
            
            AlterColumn("dbo.Addresses", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Category", c => c.String(nullable: false, maxLength: 15));
            CreateIndex("dbo.Addresses", "UserId");
            AddForeignKey("dbo.Addresses", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProductOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.ProductOrders", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.BankCards", "UserId", "dbo.Users");
            DropIndex("dbo.ProductOrders", new[] { "Order_Id" });
            DropIndex("dbo.ProductOrders", new[] { "Product_Id" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.BankCards", new[] { "UserId" });
            DropIndex("dbo.Addresses", new[] { "UserId" });
            AlterColumn("dbo.Products", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "UserId", c => c.Int());
            DropTable("dbo.ProductOrders");
            DropTable("dbo.Orders");
            DropTable("dbo.BankCards");
            RenameColumn(table: "dbo.Addresses", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Addresses", "User_Id");
            AddForeignKey("dbo.Addresses", "User_Id", "dbo.Users", "Id");
        }
    }
}
