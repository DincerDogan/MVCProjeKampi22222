namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_category_color : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryColor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryColor");
        }
    }
}
