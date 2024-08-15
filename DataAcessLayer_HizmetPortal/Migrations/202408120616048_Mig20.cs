namespace DataAcessLayer_HizmetPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Haberlers",
                c => new
                    {
                        HaberId = c.Int(nullable: false, identity: true),
                        HaberTitle = c.String(maxLength: 150),
                        HaberDescription = c.String(maxLength: 2500),
                        HaberImage = c.String(maxLength: 400),
                        HaberDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HaberId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Haberlers");
        }
    }
}
