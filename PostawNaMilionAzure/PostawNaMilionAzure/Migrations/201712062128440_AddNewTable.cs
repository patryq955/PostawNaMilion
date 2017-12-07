namespace PostawNaMilionAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsEnded = c.Boolean(nullable: false),
                        InitAccountBalance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameStepId = c.Int(nullable: false),
                        RateAnswer1 = c.Int(nullable: false),
                        RateAnswer2 = c.Int(nullable: false),
                        RateAnswer3 = c.Int(nullable: false),
                        RateAnswer4 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(maxLength: 30),
                        Name = c.String(maxLength: 300),
                        Login = c.String(maxLength: 20),
                        Address = c.String(maxLength: 100),
                        City = c.String(maxLength: 50),
                        RoleId = c.Int(nullable: false),
                        IsAtive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.UserRate");
            DropTable("dbo.Role");
            DropTable("dbo.GameStep");
            DropTable("dbo.Game");
        }
    }
}
