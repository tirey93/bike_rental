Start-Process powershell -ArgumentList "dotnet run --project .\BikeRental.BikeService\"
Start-Sleep 2
Start-Process powershell -ArgumentList "dotnet run --project .\BikeRental.StationService\"