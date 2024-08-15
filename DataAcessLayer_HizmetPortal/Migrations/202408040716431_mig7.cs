namespace DataAcessLayer_HizmetPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointments", "AppointmentEndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "AppointmentEndTime", c => c.DateTime(nullable: false));
        }
    }
}
