namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inventoryFix2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventories", "ProductId", "dbo.Products");
            DropIndex("dbo.Inventories", new[] { "ProductId" });
            DropPrimaryKey("dbo.Inventories");
            AddColumn("dbo.Products", "InventoryId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Inventories", "ProductId");
            CreateIndex("dbo.Inventories", "ProductId", unique: true);
            AddForeignKey("dbo.Inventories", "ProductId", "dbo.Products", "Id");
            DropColumn("dbo.Inventories", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventories", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Inventories", "ProductId", "dbo.Products");
            DropIndex("dbo.Inventories", new[] { "ProductId" });
            DropPrimaryKey("dbo.Inventories");
            DropColumn("dbo.Products", "InventoryId");
            AddPrimaryKey("dbo.Inventories", "Id");
            CreateIndex("dbo.Inventories", "ProductId");
            AddForeignKey("dbo.Inventories", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
