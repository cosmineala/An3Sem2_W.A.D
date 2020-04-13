
dotnet ef migrations add IdentityInitialCreate --context ApplicationDbContext --output-dir Data/Migrations/Identity
dotnet ef database update --context ApplicationDbContext
dotnet ef migrations remove --context ApplicationDbContext

dotnet ef migrations add DataAccesInitialCreate --context DataAccesDbContext --output-dir Data/Migrations/DataAcces
dotnet ef database update --context DataAccesDbContext
dotnet ef migrations remove --context DataAccesDbContext