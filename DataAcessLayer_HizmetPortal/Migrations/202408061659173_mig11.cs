namespace DataAcessLayer_HizmetPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hizmetlers",
                c => new
                    {
                        HizmetId = c.Int(nullable: false, identity: true),
                        HizmetName = c.String(maxLength: 100),
                        HizmetDestcription = c.String(maxLength: 1000),
                        HizmetImage = c.String(maxLength: 200),
                        HizmetIcon = c.String(maxLength: 200),
                        HizmetStatues = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HizmetId);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        LessonId = c.Int(nullable: false, identity: true),
                        LessonName = c.String(maxLength: 100),
                        LessonTitle = c.String(maxLength: 100),
                        LessonDestcription = c.String(maxLength: 1000),
                        LessonImage = c.String(maxLength: 200),
                        LessonStatues = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LessonId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(maxLength: 100),
                        ProjectTitle = c.String(maxLength: 100),
                        ProjectDestcription = c.String(maxLength: 1000),
                        ProjectImage = c.String(maxLength: 200),
                        ServiceStatues = c.Boolean(nullable: false),
                        StageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Stages", t => t.StageId, cascadeDelete: true)
                .Index(t => t.StageId);
            
            CreateTable(
                "dbo.Stages",
                c => new
                    {
                        StageId = c.Int(nullable: false, identity: true),
                        StageName = c.String(maxLength: 20),
                        StageStatues = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "StageId", "dbo.Stages");
            DropIndex("dbo.Projects", new[] { "StageId" });
            DropTable("dbo.Stages");
            DropTable("dbo.Projects");
            DropTable("dbo.Lessons");
            DropTable("dbo.Hizmetlers");
        }
    }
}
