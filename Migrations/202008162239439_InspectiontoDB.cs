namespace RaceTrackMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InspectiontoDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Lift", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "TireWear", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "HasTowStrap", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "HasTowStrap");
            DropColumn("dbo.Vehicles", "TireWear");
            DropColumn("dbo.Vehicles", "Lift");
        }
    }
}
