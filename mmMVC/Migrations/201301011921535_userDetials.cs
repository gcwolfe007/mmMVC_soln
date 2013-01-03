namespace mmMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userDetials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                {
                    UserId = c.Int(nullable: false, identity: true),
                    Email = c.String(nullable: false),
                    FirstName = c.String(nullable: false, maxLength: 50),
                    MiddleName = c.String(maxLength: 50),
                    LastName = c.String(nullable: false, maxLength: 50),
                    FriendlyName = c.String(maxLength: 50),
                    CreateDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    StartActiveDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    EndActiveDate = c.DateTime(nullable: false),
                    CreateUserID = c.Int(nullable: false),
                    ModifyDate = c.DateTime(nullable: false),
                    ModifyUserID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.UserId);
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "notes");
        }
    }
}
