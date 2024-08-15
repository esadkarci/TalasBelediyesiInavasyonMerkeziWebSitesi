namespace DataAcessLayer_HizmetPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        PersonelId = c.Int(nullable: false, identity: true),
                        Personelİsim = c.String(maxLength: 30),
                        PersonelSoyisim = c.String(maxLength: 30),
                        PersonelUnvan = c.String(maxLength: 30),
                        PersonelImage = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.PersonelId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personels");
        }
    }
}
