namespace TrackApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingautogenerateoptiontotheprimarykeyofLocationDatatable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LocationDatas");
            AlterColumn("dbo.LocationDatas", "ID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.LocationDatas", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.LocationDatas");
            AlterColumn("dbo.LocationDatas", "ID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.LocationDatas", "ID");
        }
    }
}
