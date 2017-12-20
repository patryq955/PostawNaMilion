namespace PostawNaMilionAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditEndGamev2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Game", "UserId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Game", new[] { "UserId_Id" });
            AddColumn("dbo.Game", "UserId", c => c.String());
            AlterColumn("dbo.Game", "Balance", c => c.Single(nullable: false));
            DropColumn("dbo.Game", "UserId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "UserId_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Game", "Balance", c => c.Int(nullable: false));
            DropColumn("dbo.Game", "UserId");
            CreateIndex("dbo.Game", "UserId_Id");
            AddForeignKey("dbo.Game", "UserId_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
