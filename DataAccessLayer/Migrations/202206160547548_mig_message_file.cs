namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_message_file : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "FilePath", c => c.String(maxLength: 250));
            AddColumn("dbo.Messages", "FileName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "FileName");
            DropColumn("dbo.Messages", "FilePath");
        }
    }
}
