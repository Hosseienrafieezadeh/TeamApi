using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Migrations
{
    [Migration(202402171705)]
    public class _202402171705_AddMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Teams")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("TeamName").AsString().NotNullable()
                .WithColumn("TshirOriginally").AsInt32().NotNullable()
                .WithColumn("TshirSub").AsInt32().NotNullable();

            Create.Table("Players")
           .WithColumn("Id").AsInt32().PrimaryKey().Identity()
           .WithColumn("PlayerName").AsString().NotNullable()
           .WithColumn("Born").AsDateTime().NotNullable()
           .WithColumn("TeamID").AsInt32().NotNullable();



            Create.ForeignKey("FK_Players_Teams")
                .FromTable("Players").ForeignColumn("TeamID")
                .ToTable("Teams").PrimaryColumn("Id");


        }
        public override void Down() 
        {
            Delete.Table("Players");
            Delete.Table("Teams");
        } 
    }

}
