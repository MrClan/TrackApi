namespace TrackApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingaconstructortoautogenerateGuidintheLocationDataobject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LocationDatas", "DeviceIdentifier", c => c.String());
            DropColumn("dbo.LocationDatas", "DeviceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LocationDatas", "DeviceId", c => c.String());
            DropColumn("dbo.LocationDatas", "DeviceIdentifier");
        }
    }
}
