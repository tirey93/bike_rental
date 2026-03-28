FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

# 1. Skopiuj kod
WORKDIR /src
COPY ../BikeRental.BikeAtStationService/ ./BikeRental.BikeAtStationService/
COPY ../BikeRental.BikeAtStationService.Contracts/ ./BikeRental.BikeAtStationService.Contracts/

# 2. Skopiuj lokalne paczki NuGet (jeśli używasz)
COPY ../nuget-local/ /packages/
RUN dotnet nuget add source /packages

# 3. Zbuduj
WORKDIR /src/BikeRental.BikeAtStationService
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# 4. Skopiuj zbudowaną aplikację
COPY --from=build /app .

# 5. Upewnij się że folder Data istnieje (dla SQLite)
RUN mkdir -p /app/Data

# 6. Uruchom
ENTRYPOINT ["dotnet", "BikeRental.BikeAtStationService.dll"]
