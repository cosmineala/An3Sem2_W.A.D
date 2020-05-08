
dotnet ef migrations add IdentityInitialCreate --context ApplicationDbContext --output-dir Data/Migrations
dotnet ef database update --context ApplicationDbContext
dotnet ef migrations remove --context ApplicationDbContext

---------------------------------------------------------------------------------------
dotnet ef migrations add DataAccesInitialCreate --context DataAccesDbContext --output-dir Data/Migrations
dotnet ef database update --context DataAccesDbContext
dotnet ef migrations remove --context DataAccesDbContext
------
add-migration "Migration_Name" -Context "DbContext_Name"

update-database -Context "DbContext_Name"

update-database -TargetMigration:"Migration_Name"


-----
Add-Migration InitialIdentity -Context ApplicationDbContext

Add-Migration InitialDataAccess -Context DataAccessDbContext

Update-Database -Context ApplicationDbContext

Update-Database -Context DataAccessDbContext

---------------

