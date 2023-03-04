# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /PB.Clients.API

COPY . .
RUN dotnet restore "PB.Clients.API/PB.Clients.API.csproj"

RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/sdk:6.0 as migration
WORKDIR /PB.Clients.Migration

COPY . .
RUN dotnet restore "PB.Clients.Migration/PB.Clients.Migration.csproj"
RUN dotnet build -c Release -o /app/migration

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /migration
COPY --from=migration /app/migration .

WORKDIR /publish
COPY --from=build-env /publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "PB.Clients.API.dll"]
