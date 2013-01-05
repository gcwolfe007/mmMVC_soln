namespace mmMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "notes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "notes", c => c.String());
        }
    }
}
