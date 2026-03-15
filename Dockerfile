# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY OsrsCalcTool.Api/OsrsCalcTool.Api.csproj OsrsCalcTool.Api/
RUN dotnet restore OsrsCalcTool.Api/OsrsCalcTool.Api.csproj

COPY . .
RUN dotnet publish OsrsCalcTool.Api/OsrsCalcTool.Api.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "OsrsCalcTool.Api.dll"]
