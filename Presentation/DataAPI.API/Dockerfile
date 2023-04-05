#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Presentation/DataAPI.API/DataAPI.API.csproj", "Presentation/DataAPI.API/"]
COPY ["Core/DataAPI.Application/DataAPI.Application.csproj", "Core/DataAPI.Application/"]
COPY ["Core/DataAPI.Domain/DataAPI.Domain.csproj", "Core/DataAPI.Domain/"]
COPY ["Infrastructure/DataAPI.Infrastructure/DataAPI.Infrastructure.csproj", "Infrastructure/DataAPI.Infrastructure/"]
COPY ["Infrastructure/DataAPI.Persistence/DataAPI.Persistence.csproj", "Infrastructure/DataAPI.Persistence/"]
RUN dotnet restore "Presentation/DataAPI.API/DataAPI.API.csproj"
RUN dotnet ef database update
COPY . .
WORKDIR "/src/Presentation/DataAPI.API"
RUN dotnet build "DataAPI.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataAPI.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataAPI.API.dll"]