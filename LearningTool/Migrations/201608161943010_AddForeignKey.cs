namespace LearningTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tests", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Tests", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Tests", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Tests", name: "UserId", newName: "User_Id");
        }
    }
}
