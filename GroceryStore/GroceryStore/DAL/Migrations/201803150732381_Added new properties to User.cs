namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddednewpropertiestoUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Phone number", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Users", "First name", c => c.String(maxLength: 20));
            AddColumn("dbo.Users", "Last name", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Last name");
            DropColumn("dbo.Users", "First name");
            DropColumn("dbo.Users", "Phone number");
        }
    }
}
