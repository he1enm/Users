# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiază fișierele de proiect și restore dependințele
COPY ./users/src/users.Api/*.csproj ./users/src/users.Api/
RUN dotnet restore ./users/src/users.Api/users.Api.csproj

# Copiază restul codului și build
COPY . .
RUN dotnet publish ./users/src/users.Api/users.Api.csproj -c Release -o /app/publish

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expune portul (ajustează dacă aplicația rulează pe alt port)
EXPOSE 80

# Comandă de pornire
ENTRYPOINT ["dotnet", "users.Api.dll"]
