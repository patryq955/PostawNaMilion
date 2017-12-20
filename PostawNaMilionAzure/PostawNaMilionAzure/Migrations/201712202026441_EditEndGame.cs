namespace PostawNaMilionAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditEndGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "StageEnd", c => c.Int(nullable: false));
            AddColumn("dbo.Game", "Balance", c => c.Int(nullable: false));
            AddColumn("dbo.Game", "UserId_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Game", "UserId_Id");
            AddForeignKey("dbo.Game", "UserId_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Game", "UserId");
            DropColumn("dbo.Game", "IsEnded");
            DropColumn("dbo.Game", "InitAccountBalance");
            DropTable("dbo.GameStep");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GameStep",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        ActualAccountBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Game", "InitAccountBalance", c => c.Int(nullable: false));
            AddColumn("dbo.Game", "IsEnded", c => c.Boolean(nullable: false));
            AddColumn("dbo.Game", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Game", "UserId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Game", new[] { "UserId_Id" });
            DropColumn("dbo.Game", "UserId_Id");
            DropColumn("dbo.Game", "Balance");
            DropColumn("dbo.Game", "StageEnd");
        }
    }
}
