# --- ETAPA 1: COMPILACIÓN ---
# Usamos la imagen del SDK de .NET 8
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos el archivo del proyecto y restauramos las dependencias
# (Esto se hace en una capa separada para aprovechar la caché de Docker)
COPY ["ApiPlayLists.csproj", "."]
RUN dotnet restore

# Copiamos el resto del código y compilamos la aplicación en modo Release
COPY . .
RUN dotnet publish -c Release -o /app/publish

# --- ETAPA 2: RUNTIME ---
# Usamos la imagen del runtime de ASP.NET Core 8, que es más ligera
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiamos los binarios compilados desde la etapa de compilación
COPY --from=build /app/publish .

# Variable de entorno para que ASP.NET Core sepa que está en un contenedor
ENV ASPNETCORE_ENVIRONMENT=Production
# Exponemos el puerto que usará la aplicación (por defecto, 8080 para la imagen aspnet)
EXPOSE 8080

# Comando para iniciar la aplicación
ENTRYPOINT ["dotnet", "ApiPlayLists.dll"]