namespace DataAcessLayer_HizmetPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig14 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Hizmetlers", "HizmetIcon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hizmetlers", "HizmetIcon", c => c.String(maxLength: 200));
        }
    }
}
