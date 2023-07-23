namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixheading : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Headings", "HeadingName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Headings", "HeadingName", c => c.String(maxLength: 50));
        }
    }
}
