namespace DataAcessLayer_HizmetPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ProjectStatues", c => c.Boolean(nullable: false));
            DropColumn("dbo.Projects", "ServiceStatues");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "ServiceStatues", c => c.Boolean(nullable: false));
            DropColumn("dbo.Projects", "ProjectStatues");
        }
    }
}
