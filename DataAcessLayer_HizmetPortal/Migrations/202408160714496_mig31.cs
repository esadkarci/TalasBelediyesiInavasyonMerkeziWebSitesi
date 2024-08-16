namespace DataAcessLayer_HizmetPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personels", "PersonelCV", c => c.String());
            AddColumn("dbo.Projects", "ProjectDescription", c => c.String(maxLength: 1000));
            DropColumn("dbo.Projects", "ProjectName");
            DropColumn("dbo.Projects", "ProjectDestcription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "ProjectDestcription", c => c.String(maxLength: 1000));
            AddColumn("dbo.Projects", "ProjectName", c => c.String(maxLength: 100));
            DropColumn("dbo.Projects", "ProjectDescription");
            DropColumn("dbo.Personels", "PersonelCV");
        }
    }
}
