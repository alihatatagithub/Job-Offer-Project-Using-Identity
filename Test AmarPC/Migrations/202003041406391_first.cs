namespace Test_AmarPC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplyForJobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        ApplyDate = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.JobId);
            
            AddColumn("dbo.Jobs", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "appRole_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Jobs", "UserId");
            CreateIndex("dbo.AspNetUsers", "appRole_Id");
            AddForeignKey("dbo.AspNetUsers", "appRole_Id", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.Jobs", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplyForJobs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplyForJobs", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "appRole_Id", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUsers", new[] { "appRole_Id" });
            DropIndex("dbo.Jobs", new[] { "UserId" });
            DropIndex("dbo.ApplyForJobs", new[] { "JobId" });
            DropIndex("dbo.ApplyForJobs", new[] { "UserId" });
            DropColumn("dbo.AspNetUsers", "appRole_Id");
            DropColumn("dbo.Jobs", "UserId");
            DropTable("dbo.ApplyForJobs");
        }
    }
}
