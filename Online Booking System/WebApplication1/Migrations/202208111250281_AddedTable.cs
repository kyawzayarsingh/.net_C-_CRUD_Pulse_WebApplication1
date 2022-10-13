namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageAttachments", "UserId", "dbo.Users");
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Package_Id = c.Int(nullable: false),
                        Guest_No = c.Int(nullable: false),
                        Booking_Date = c.DateTime(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Booking_Remark = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .Index(t => t.Package_Id);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Destination_Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        Price = c.Double(nullable: false),
                        Created_User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Destinations", t => t.Destination_Id)
                .ForeignKey("dbo.Users", t => t.Created_User_Id)
                .Index(t => t.Destination_Id)
                .Index(t => t.Created_User_Id);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        City = c.String(nullable: false),
                        Division = c.String(nullable: false),
                        Created_User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Created_User_Id)
                .Index(t => t.Created_User_Id);
            
            AddForeignKey("dbo.ImageAttachments", "UserId", "dbo.Users", "Id");
            DropColumn("dbo.ImageAttachments", "EncId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImageAttachments", "EncId", c => c.String());
            DropForeignKey("dbo.ImageAttachments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Bookings", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.Packages", "Created_User_Id", "dbo.Users");
            DropForeignKey("dbo.Packages", "Destination_Id", "dbo.Destinations");
            DropForeignKey("dbo.Destinations", "Created_User_Id", "dbo.Users");
            DropIndex("dbo.Destinations", new[] { "Created_User_Id" });
            DropIndex("dbo.Packages", new[] { "Created_User_Id" });
            DropIndex("dbo.Packages", new[] { "Destination_Id" });
            DropIndex("dbo.Bookings", new[] { "Package_Id" });
            DropTable("dbo.Destinations");
            DropTable("dbo.Packages");
            DropTable("dbo.Bookings");
            AddForeignKey("dbo.ImageAttachments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
