namespace ChurchWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 30),
                        Request = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Leaders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Picture = c.Binary(nullable: false),
                        ImageSize = c.Int(nullable: false),
                        Position = c.String(nullable: false),
                        MinistryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ministries", t => t.MinistryID, cascadeDelete: true)
                .Index(t => t.MinistryID);
            
            CreateTable(
                "dbo.Ministries",
                c => new
                    {
                        MinistryID = c.Int(nullable: false, identity: true),
                        MinistryName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.MinistryID);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Role = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 30),
                        Pass = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leaders", "MinistryID", "dbo.Ministries");
            DropIndex("dbo.Leaders", new[] { "MinistryID" });
            DropTable("dbo.UserInfoes");
            DropTable("dbo.Ministries");
            DropTable("dbo.Leaders");
            DropTable("dbo.Emails");
        }
    }
}
