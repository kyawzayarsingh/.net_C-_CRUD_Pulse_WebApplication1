namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedClassNameInttoString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblClasses", "ClassName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblClasses", "ClassName", c => c.Int(nullable: false));
        }
    }
}
