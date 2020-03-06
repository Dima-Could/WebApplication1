namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameOfMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT MembershipTypes ON");
            Sql("INSERT INTO MembershipTypes (Id, Name) VALUES (1, 'Vip')");
            Sql("INSERT INTO MembershipTypes (Id, Name) VALUES (2, 'Middle')");
            Sql("INSERT INTO MembershipTypes (Id, Name) VALUES (3, 'Simple')");
            Sql("SET IDENTITY_INSERT MembershipTypes OFF");
        }
        
        public override void Down()
        {
        }
    }
}
