namespace PostawNaMilionAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    QuestionId = c.Int(nullable: false),
                    Contents = c.String(),
                    IsCorrect = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.CategoryDict",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                    KnowledgeAreaId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.KnowledgeArea",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Question",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Contents = c.String(),
                    Level = c.Int(nullable: false),
                    CategoryDictId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Question");
            DropTable("dbo.KnowledgeArea");
            DropTable("dbo.CategoryDict");
            DropTable("dbo.Answer");
        }
    }
}
