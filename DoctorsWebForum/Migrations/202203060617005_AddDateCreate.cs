namespace DoctorsWebForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "DateCreate", c => c.String());
            AddColumn("dbo.Clients", "DateCreate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "DateCreate");
            DropColumn("dbo.Doctors", "DateCreate");
        }
    }
}
