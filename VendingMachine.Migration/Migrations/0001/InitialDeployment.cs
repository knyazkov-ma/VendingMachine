using FluentMigrator;

namespace VendingMachine.Migration.Migrations
{
    [Migration(20171031103030, "InitialDeployment")]
    public class InitialDeployment : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("create-database.sql");
        }
    }
}