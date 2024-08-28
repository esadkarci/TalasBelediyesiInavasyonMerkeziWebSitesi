namespace DataAcessLayer_HizmetPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class miggaleri : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galeris",
                c => new
                    {
                        GaleriId = c.Int(nullable: false, identity: true),
                        GaleriImage = c.String(maxLength: 500),
                        GaleriStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GaleriId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Galeris");
        }
    }
}
