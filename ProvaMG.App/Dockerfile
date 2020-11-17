FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY "ProvaMG.sln" "ProvaMG.sln"
COPY "ProvaMG.Api/ProvaMG.Api.csproj" "ProvaMG.Api/ProvaMG.Api.csproj"
COPY "ProvaMG.App/ProvaMG.App.csproj" "ProvaMG.App/ProvaMG.App.csproj"
COPY "ProvaMG.Application/ProvaMG.Application.csproj" "ProvaMG.Application/ProvaMG.Application.csproj"
COPY "ProvaMG.Application.IntegrationTests/ProvaMG.Application.IntegrationTests.csproj" "ProvaMG.Application.IntegrationTests/ProvaMG.Application.IntegrationTests.csproj"
COPY "ProvaMG.Domain/ProvaMG.Domain.csproj" "ProvaMG.Domain/ProvaMG.Domain.csproj"
COPY "ProvaMG.Infrasctructure/ProvaMG.Infrasctructure.csproj" "ProvaMG.Infrasctructure/ProvaMG.Infrasctructure.csproj"
COPY "ProvaMG.Infrasctructure.IntegrationTests/ProvaMG.Infrasctructure.IntegrationTests.csproj" "ProvaMG.Infrasctructure.IntegrationTests/ProvaMG.Infrasctructure.IntegrationTests.csproj"
RUN dotnet restore

COPY . .
WORKDIR /src/ProvaMG.App
RUN dotnet publish -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProvaMG.App.dll"]