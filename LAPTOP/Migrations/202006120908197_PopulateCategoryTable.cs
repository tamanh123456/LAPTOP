namespace LAPTOP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CATEGORIES (ID, BRAND) VALUES (1, 'MSI')");
            Sql("INSERT INTO CATEGORIES (ID, BRAND) VALUES (2, 'ACER')");
            Sql("INSERT INTO CATEGORIES (ID, BRAND) VALUES (3, 'ASUS')");
            Sql("INSERT INTO CATEGORIES (ID, BRAND) VALUES (4, 'DELL')");
            Sql("INSERT INTO CATEGORIES (ID, BRAND) VALUES (5, 'HP')");
        }
        
        public override void Down()
        {
        }
    }
}
