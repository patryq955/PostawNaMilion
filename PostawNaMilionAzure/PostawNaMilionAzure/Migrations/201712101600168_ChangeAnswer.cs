namespace PostawNaMilionAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Question", "IsHidden", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Answer", "Contents", c => c.String(nullable: false, maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Answer", "Contents", c => c.String(maxLength: 300));
            DropColumn("dbo.Question", "IsHidden");
        }
    }
}
