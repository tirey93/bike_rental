1. In order to migrate db do the following step in your service folder:
dotnet tool install --global dotnet-ef
dotnet ef database update

2. In order to add new migration use:
dotnet ef migrations add "Init" --output-dir "Infrastructure/Migrations"
