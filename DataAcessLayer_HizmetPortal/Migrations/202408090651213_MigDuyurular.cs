namespace DataAcessLayer_HizmetPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigDuyurular : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Duyurulars",
                c => new
                    {
                        DuyurularId = c.Int(nullable: false, identity: true),
                        DuyurularImage = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.DuyurularId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Duyurulars");
        }
    }
}
