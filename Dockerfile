#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/DataTransfer.HttpApi.Host/DataTransfer.HttpApi.Host.csproj", "src/DataTransfer.HttpApi.Host/"]
COPY ["src/DataTransfer.EntityFramework.Migration/DataTransfer.EntityFramework.DbMigrations.csproj", "src/DataTransfer.EntityFramework.Migration/"]
COPY ["src/DataTransfer.EntityFramework/DataTransfer.EntityFramework.csproj", "src/DataTransfer.EntityFramework/"]
COPY ["src/DataTransfer.Domain/DataTransfer.Domain.csproj", "src/DataTransfer.Domain/"]
COPY ["src/DataTransfer.Domain.Shared/DataTransfer.Domain.Shared.csproj", "src/DataTransfer.Domain.Shared/"]
COPY ["src/DataTransfer.Application/DataTransfer.Application.csproj", "src/DataTransfer.Application/"]
COPY ["src/DataTransfer.Infrastructure/DataTransfer.Infrastructure.csproj", "src/DataTransfer.Infrastructure/"]
COPY ["src/DataTransfer.Application.Contracts/DataTransfer.Application.Contracts.csproj", "src/DataTransfer.Application.Contracts/"]
RUN dotnet restore "src/DataTransfer.HttpApi.Host/DataTransfer.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/DataTransfer.HttpApi.Host"
RUN dotnet build "DataTransfer.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataTransfer.HttpApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataTransfer.HttpApi.Host.dll"]