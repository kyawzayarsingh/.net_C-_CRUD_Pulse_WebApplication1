namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTwoTabletblStudentsAndtblClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblClasses",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        ClassName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassId);
            
            CreateTable(
                "dbo.tblStudents",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.tblClasses", t => t.ClassId)
                .Index(t => t.ClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblStudents", "ClassId", "dbo.tblClasses");
            DropIndex("dbo.tblStudents", new[] { "ClassId" });
            DropTable("dbo.tblStudents");
            DropTable("dbo.tblClasses");
        }
    }
}
