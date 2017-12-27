namespace PostawNaMilionAzure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStepTotalValue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StepAddSubTotalValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StepValue = c.Int(nullable: false),
                        DateAdd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StepAddSubTotalValues");
        }
    }
}
