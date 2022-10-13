namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageAttachmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageAttachments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EncId = c.String(),
                        UserId = c.Int(nullable: false),
                        FileName = c.String(nullable: false, maxLength: 200),
                        FileType = c.String(nullable: false, maxLength: 5),
                        FileBase64 = c.String(nullable: false),
                        FileSize = c.String(),
                        LastUpdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastUpdatedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Users", "LastUpdate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Users", "LastUpdatedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Phone", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Users", "Address", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageAttachments", "UserId", "dbo.Users");
            DropIndex("dbo.ImageAttachments", new[] { "UserId" });
            AlterColumn("dbo.Users", "Address", c => c.String());
            AlterColumn("dbo.Users", "Phone", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
            DropColumn("dbo.Users", "LastUpdatedBy");
            DropColumn("dbo.Users", "LastUpdate");
            DropTable("dbo.ImageAttachments");
        }
    }
}
