namespace MVCCrudCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Mobile", c => c.String());
            AddColumn("dbo.Employees", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Age");
            DropColumn("dbo.Employees", "Mobile");
        }
    }
}
