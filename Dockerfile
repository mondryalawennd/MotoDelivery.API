
# Etapa 0: Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Variáveis para evitar problemas com fallback
ENV DOTNET_NOLOGO=true \
    DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true \
    DOTNET_CLI_TELEMETRY_OPTOUT=1 \
    NUGET_PACKAGES=/root/.nuget/packages \
    DOTNET_RESTORE_DISABLE_PARALLEL=true \
    DOTNET_RESTORE_USEFALLBACKFOLDER=false

# Copiar os arquivos .csproj de todos os projetos
COPY MotoDelivery.API/MotoDelivery.API.csproj MotoDelivery.API/
COPY MotoDelivery.Application/MotoDelivery.Application.csproj MotoDelivery.Application/
COPY MotoDelivery.Common/MotoDelivery.Common.csproj MotoDelivery.Common/
COPY MotoDelivery.Domain/MotoDelivery.Domain.csproj MotoDelivery.Domain/
COPY MotoDelivery.Infrastructure/MotoDelivery.Infrastructure.csproj MotoDelivery.Infrastructure/
COPY MotoDelivery.ORM/MotoDelivery.ORM.csproj MotoDelivery.ORM/


# Restaurar pacotes
RUN dotnet restore "./MotoDelivery.API/MotoDelivery.API.csproj" --no-cache

# Copiar todo o restante do código
COPY . .

# Build da aplicação
WORKDIR "/src/MotoDelivery.API"
RUN dotnet build "./MotoDelivery.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa 2: Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MotoDelivery.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa 3: Runtime final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MotoDelivery.API.dll"]