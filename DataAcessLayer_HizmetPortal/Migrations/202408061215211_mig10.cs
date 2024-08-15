namespace DataAcessLayer_HizmetPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personels", "PersonelIsim", c => c.String(maxLength: 30));
            DropColumn("dbo.Personels", "Personelİsim");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personels", "Personelİsim", c => c.String(maxLength: 30));
            DropColumn("dbo.Personels", "PersonelIsim");
        }
    }
}
