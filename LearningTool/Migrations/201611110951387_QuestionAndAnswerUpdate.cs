namespace LearningTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionAndAnswerUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hints", "QuestionAndAnswer_Id", "dbo.QuestionAndAnswers");
            DropIndex("dbo.Hints", new[] { "QuestionAndAnswer_Id" });
            AddColumn("dbo.QuestionAndAnswers", "Hint", c => c.String(maxLength: 255));
            AddColumn("dbo.QuestionAndAnswers", "Mnemonic", c => c.String(maxLength: 255));
            AlterColumn("dbo.QuestionAndAnswers", "Question", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.QuestionAndAnswers", "Answer", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Hints", "QuestionAndAnswer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hints", "QuestionAndAnswer_Id", c => c.Int());
            AlterColumn("dbo.QuestionAndAnswers", "Answer", c => c.String(nullable: false));
            AlterColumn("dbo.QuestionAndAnswers", "Question", c => c.String(nullable: false));
            DropColumn("dbo.QuestionAndAnswers", "Mnemonic");
            DropColumn("dbo.QuestionAndAnswers", "Hint");
            CreateIndex("dbo.Hints", "QuestionAndAnswer_Id");
            AddForeignKey("dbo.Hints", "QuestionAndAnswer_Id", "dbo.QuestionAndAnswers", "Id");
        }
    }
}
