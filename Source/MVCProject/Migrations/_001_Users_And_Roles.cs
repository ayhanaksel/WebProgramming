using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MVCProject.Migrations
{
    [Migration(1)]
    public class _001_Users_And_Roles : Migration
    {
        public override void Down()
        {            
            Delete.Table("Role_Users");
            Delete.Table("Roles");
            Delete.Table("Users");
        }

        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Username").AsString(128)
                .WithColumn("Email").AsString(256)
                .WithColumn("Password_Hash").AsString(128);

            Create.Table("Roles")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString(128);

            Create.Table("Role_Users")
                .WithColumn("User_Id").AsInt32().ForeignKey("Users","Id").OnDelete(Rule.Cascade)
                .WithColumn("Role_Id").AsInt32().ForeignKey("Roles","Id").OnDelete(Rule.Cascade);
        }
    }
}