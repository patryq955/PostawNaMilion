namespace PostawNaMilionAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeQuestion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Question", "Contents", c => c.String(nullable: false, maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Question", "Contents", c => c.String(maxLength: 300));
        }
    }
}
