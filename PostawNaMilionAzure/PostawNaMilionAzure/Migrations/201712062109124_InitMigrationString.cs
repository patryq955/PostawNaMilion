namespace PostawNaMilionAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigrationString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answer", "Contents", c => c.String(maxLength: 300));
            AlterColumn("dbo.CategoryDict", "Name", c => c.String(maxLength: 300));
            AlterColumn("dbo.CategoryDict", "Description", c => c.String(maxLength: 300));
            AlterColumn("dbo.KnowledgeArea", "Name", c => c.String(maxLength: 300));
            AlterColumn("dbo.KnowledgeArea", "Description", c => c.String(maxLength: 300));
            AlterColumn("dbo.Question", "Contents", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Question", "Contents", c => c.String());
            AlterColumn("dbo.KnowledgeArea", "Description", c => c.String());
            AlterColumn("dbo.KnowledgeArea", "Name", c => c.String());
            AlterColumn("dbo.CategoryDict", "Description", c => c.String());
            AlterColumn("dbo.CategoryDict", "Name", c => c.String());
            AlterColumn("dbo.Answer", "Contents", c => c.String());
        }
    }
}
