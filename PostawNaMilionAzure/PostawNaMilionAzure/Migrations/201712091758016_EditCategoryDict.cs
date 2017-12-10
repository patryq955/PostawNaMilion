namespace PostawNaMilionAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditCategoryDict : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CategoryDict", "IsHidden", c => c.Boolean(nullable: false));
            AlterColumn("dbo.CategoryDict", "Name", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.CategoryDict", "Description", c => c.String(nullable: false, maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CategoryDict", "Description", c => c.String(maxLength: 300));
            AlterColumn("dbo.CategoryDict", "Name", c => c.String(maxLength: 300));
            DropColumn("dbo.CategoryDict", "IsHidden");
        }
    }
}
