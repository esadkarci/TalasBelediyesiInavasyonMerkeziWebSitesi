namespace DataAcessLayer_HizmetPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class duzenleme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Duyurulars", "DuyurularStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Haberlers", "HaberlerStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Hizmetlers", "HizmetDescription", c => c.String(maxLength: 1000));
            AddColumn("dbo.Hizmetlers", "HizmetStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Lessons", "LessonDescription", c => c.String(maxLength: 1000));
            AddColumn("dbo.Personels", "PersonelStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Projects", "ProjectStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Stages", "StageStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Hizmetlers", "HizmetDestcription");
            DropColumn("dbo.Hizmetlers", "HizmetStatues");
            DropColumn("dbo.Lessons", "LessonDestcription");
            DropColumn("dbo.Projects", "ProjectStatues");
            DropColumn("dbo.Stages", "StageStatues");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stages", "StageStatues", c => c.Boolean(nullable: false));
            AddColumn("dbo.Projects", "ProjectStatues", c => c.Boolean(nullable: false));
            AddColumn("dbo.Lessons", "LessonDestcription", c => c.String(maxLength: 1000));
            AddColumn("dbo.Hizmetlers", "HizmetStatues", c => c.Boolean(nullable: false));
            AddColumn("dbo.Hizmetlers", "HizmetDestcription", c => c.String(maxLength: 1000));
            DropColumn("dbo.Stages", "StageStatus");
            DropColumn("dbo.Projects", "ProjectStatus");
            DropColumn("dbo.Personels", "PersonelStatus");
            DropColumn("dbo.Lessons", "LessonDescription");
            DropColumn("dbo.Hizmetlers", "HizmetStatus");
            DropColumn("dbo.Hizmetlers", "HizmetDescription");
            DropColumn("dbo.Haberlers", "HaberlerStatus");
            DropColumn("dbo.Duyurulars", "DuyurularStatus");
        }
    }
}
