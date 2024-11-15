#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
# Install clang/zlib1g-dev dependencies for publishing to native
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    clang zlib1g-dev
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Bitbound.WebSocketBridge/Bitbound.WebSocketBridge.csproj", "Bitbound.WebSocketBridge/"]
COPY ["Bitbound.WebSocketBridge.Common/Bitbound.WebSocketBridge.Common.csproj", "Bitbound.WebSocketBridge.Common/"]
RUN dotnet restore "./Bitbound.WebSocketBridge/Bitbound.WebSocketBridge.csproj"
COPY . .
WORKDIR "/src/Bitbound.WebSocketBridge"
RUN dotnet build "./Bitbound.WebSocketBridge.csproj" -c $BUILD_CONFIGURATION -p:GeneratePackageOnBuild=false -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Bitbound.WebSocketBridge.csproj" -c $BUILD_CONFIGURATION -p:GeneratePackageOnBuild=false -o /app/publish /p:UseAppHost=true

FROM mcr.microsoft.com/dotnet/runtime-deps:9.0 AS final
RUN apt-get -y update
RUN apt-get -y install curl
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["./Bitbound.WebSocketBridge"]

HEALTHCHECK \
  CMD curl -f http://localhost:8080/api/health || exit 1