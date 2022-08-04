#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Catalog/Catalog.WebApi/Catalog.WebApi.csproj", "Services/Catalog/Catalog.WebApi/"]
COPY ["Services/Catalog/Catalog.Application/Catalog.Application.csproj", "Services/Catalog/Catalog.Application/"]
COPY ["Services/Catalog/Catalog.Domain/Catalog.Domain.csproj", "Services/Catalog/Catalog.Domain/"]
COPY ["Services/Catalog/Catalog.Infostructure/Catalog.Infostructure.csproj", "Services/Catalog/Catalog.Infostructure/"]
RUN dotnet restore "Services/Catalog/Catalog.WebApi/Catalog.WebApi.csproj"
COPY . .
WORKDIR "/src/Services/Catalog/Catalog.WebApi"
RUN dotnet build "Catalog.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog.WebApi.dll"]