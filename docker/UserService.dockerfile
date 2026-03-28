FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

# 1. Skopiuj kod
WORKDIR /src
COPY ../BikeRental.UserService/ ./BikeRental.UserService/
COPY ../BikeRental.UserService.Contracts/ ./BikeRental.UserService.Contracts/
COPY ../BikeRental.UserService.UnitTests/ ./BikeRental.UserService.UnitTests/

# 2. Skopiuj lokalne paczki NuGet (jesli uzywasz)
COPY ../nuget-local/ /packages/
RUN dotnet nuget add source /packages

# 3. Zbuduj
WORKDIR /src/BikeRental.UserService
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# 4. Skopiuj zbudowana aplikacje
COPY --from=build /app .

# 5. Upewnij sie ze folder Data istnieje (dla SQLite)
RUN mkdir -p /app/Data

# 6. Uruchom
ENTRYPOINT ["dotnet", "BikeRental.UserService.dll"]
