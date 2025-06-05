# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiază fișierele de proiect și restore dependințele
COPY ./src/Users.Api/*.csproj ./src/Users.Api/
RUN dotnet restore ./src/Users.Api/Users.Api.csproj

# Copiază restul codului și build
COPY . .
RUN dotnet publish ./src/Users.Api/Users.Api.csproj -c Release -o /app/publish

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expune portul (ajustează dacă aplicația rulează pe alt port)
EXPOSE 80

# Comandă de pornire
ENTRYPOINT ["dotnet", "users.Api.dll"]
