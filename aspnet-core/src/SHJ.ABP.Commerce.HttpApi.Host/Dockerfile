#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/SHJ.ABP.Commerce.HttpApi.Host/SHJ.ABP.Commerce.HttpApi.Host.csproj", "src/SHJ.ABP.Commerce.HttpApi.Host/"]
COPY ["src/SHJ.ABP.Commerce.Application/SHJ.ABP.Commerce.Application.csproj", "src/SHJ.ABP.Commerce.Application/"]
COPY ["src/SHJ.ABP.Commerce.Domain/SHJ.ABP.Commerce.Domain.csproj", "src/SHJ.ABP.Commerce.Domain/"]
COPY ["src/SHJ.ABP.Commerce.Domain.Shared/SHJ.ABP.Commerce.Domain.Shared.csproj", "src/SHJ.ABP.Commerce.Domain.Shared/"]
COPY ["src/SHJ.ABP.Commerce.Application.Contracts/SHJ.ABP.Commerce.Application.Contracts.csproj", "src/SHJ.ABP.Commerce.Application.Contracts/"]
COPY ["src/SHJ.ABP.Commerce.EntityFrameworkCore/SHJ.ABP.Commerce.EntityFrameworkCore.csproj", "src/SHJ.ABP.Commerce.EntityFrameworkCore/"]
COPY ["src/SHJ.ABP.Commerce.HttpApi/SHJ.ABP.Commerce.HttpApi.csproj", "src/SHJ.ABP.Commerce.HttpApi/"]
RUN dotnet restore "./src/SHJ.ABP.Commerce.HttpApi.Host/./SHJ.ABP.Commerce.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/SHJ.ABP.Commerce.HttpApi.Host"
RUN dotnet build "./SHJ.ABP.Commerce.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SHJ.ABP.Commerce.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SHJ.ABP.Commerce.HttpApi.Host.dll"]