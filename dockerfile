# Use the official .NET runtime as a base
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

# Use the SDK to build the app
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# SQLite needs write permissions on the app folder
USER root
RUN chmod -R 777 /app
USER $APP_UID

ENTRYPOINT ["dotnet", "YourAppName.dll"]