namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameOfMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Vip' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Middle' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Simple' WHERE Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
