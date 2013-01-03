namespace mmMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserProfile", "CreateUserID", c => c.Int(nullable: false));
            AddColumn("dbo.UserProfile", "ModifyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserProfile", "ModifyUserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfile", "ModifyUserID");
            DropColumn("dbo.UserProfile", "ModifyDate");
            DropColumn("dbo.UserProfile", "CreateUserID");
            DropColumn("dbo.UserProfile", "CreateDate");
        }
    }
}
