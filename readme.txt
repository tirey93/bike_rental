1. In order to migrate db do the following step in your service folder:
dotnet tool install --global dotnet-ef
dotnet ef database update

2. In order to add new migration use:
dotnet ef migrations add "Init" --output-dir "Infrastructure/Migrations"

3. RabbitMQ installation
docker run -d --hostname my-rabbit --name some-rabbit -p 5672:5672 -p 8080:15672 rabbitmq:3-management