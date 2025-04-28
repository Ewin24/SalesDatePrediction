# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar los archivos de solución y proyectos
COPY SalesDatePrediction.sln ./
COPY API/API.csproj ./API/
COPY Aplicacion/Aplication.csproj ./Aplicacion/
COPY Dominio/Domain.csproj ./Dominio/
COPY Persistence/Persistence.csproj ./Persistence/

# Restaurar dependencias
RUN dotnet restore

# Copiar el resto del código fuente y compilar
COPY . .
WORKDIR /app/API
RUN dotnet publish -c Release -o /out

# Etapa 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar los archivos publicados desde la etapa de construcción
COPY --from=build /out .

# Exponer los puertos utilizados por la API
EXPOSE 5000
EXPOSE 5001

# Configurar el punto de entrada para ejecutar la API
ENTRYPOINT ["dotnet", "API.dll"]