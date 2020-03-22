namespace Test_AmarPC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Valid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "JobTitle", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Jobs", "JobContent", c => c.String(nullable: false));
            AlterColumn("dbo.Jobs", "JobImage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "JobImage", c => c.String());
            AlterColumn("dbo.Jobs", "JobContent", c => c.String());
            AlterColumn("dbo.Jobs", "JobTitle", c => c.String());
        }
    }
}
