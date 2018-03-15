namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BankCardValidationsAdded : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.BankCards");
            AlterColumn("dbo.BankCards", "Number", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.BankCards", "Name", c => c.String(nullable: false, maxLength: 30));
            AddPrimaryKey("dbo.BankCards", new[] { "Number", "ExpirationDate" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.BankCards");
            AlterColumn("dbo.BankCards", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.BankCards", "Number", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.BankCards", new[] { "Number", "ExpirationDate" });
        }
    }
}
