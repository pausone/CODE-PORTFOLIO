namespace LearningTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionAndAnswers", "Test_Id", "dbo.Tests");
            DropIndex("dbo.QuestionAndAnswers", new[] { "Test_Id" });
            RenameColumn(table: "dbo.QuestionAndAnswers", name: "Test_Id", newName: "TestId");
            AlterColumn("dbo.QuestionAndAnswers", "TestId", c => c.Int(nullable: false));
            CreateIndex("dbo.QuestionAndAnswers", "TestId");
            AddForeignKey("dbo.QuestionAndAnswers", "TestId", "dbo.Tests", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionAndAnswers", "TestId", "dbo.Tests");
            DropIndex("dbo.QuestionAndAnswers", new[] { "TestId" });
            AlterColumn("dbo.QuestionAndAnswers", "TestId", c => c.Int());
            RenameColumn(table: "dbo.QuestionAndAnswers", name: "TestId", newName: "Test_Id");
            CreateIndex("dbo.QuestionAndAnswers", "Test_Id");
            AddForeignKey("dbo.QuestionAndAnswers", "Test_Id", "dbo.Tests", "Id");
        }
    }
}
