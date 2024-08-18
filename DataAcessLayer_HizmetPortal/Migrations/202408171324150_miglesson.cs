namespace DataAcessLayer_HizmetPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class miglesson : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Lessons", "LessonName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "LessonName", c => c.String(maxLength: 100));
        }
    }
}
