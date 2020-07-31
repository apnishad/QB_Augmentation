namespace DoctorAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AID = c.Int(nullable: false, identity: true),
                        PatientID = c.Int(nullable: false),
                        ADate = c.DateTime(nullable: false),
                        ATime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        AStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AID)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .Index(t => t.PatientID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        Mobile = c.String(),
                    })
                .PrimaryKey(t => t.PID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "PatientID", "dbo.Patients");
            DropIndex("dbo.Appointments", new[] { "PatientID" });
            DropTable("dbo.Patients");
            DropTable("dbo.Appointments");
        }
    }
}
