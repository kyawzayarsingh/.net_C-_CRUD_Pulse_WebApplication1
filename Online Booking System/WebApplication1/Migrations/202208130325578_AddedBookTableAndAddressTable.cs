namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBookTableAndAddressTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        HomeNo = c.Int(nullable: false, identity: true),
                        AddressCode = c.String(nullable: false),
                        PhoneNo = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.HomeNo);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        Price = c.String(nullable: false),
                        Address_HomeNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_HomeNo)
                .Index(t => t.Address_HomeNo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Address_HomeNo", "dbo.Addresses");
            DropIndex("dbo.Books", new[] { "Address_HomeNo" });
            DropTable("dbo.Books");
            DropTable("dbo.Addresses");
        }
    }
}
