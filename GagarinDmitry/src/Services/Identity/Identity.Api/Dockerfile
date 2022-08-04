#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Identity/Identity.Api/Identity.WebApi.csproj", "Services/Identity/Identity.Api/"]
COPY ["Services/Identity/Identity.Application/Identity.Application.csproj", "Services/Identity/Identity.Application/"]
COPY ["Services/Identity/Identity.Domain/Identity.Domain.csproj", "Services/Identity/Identity.Domain/"]
COPY ["BuildingBlocks/SharedModels/SharedModels.csproj", "BuildingBlocks/SharedModels/"]
COPY ["Services/Identity/Identity.Infostructure/Identity.Infostructure.csproj", "Services/Identity/Identity.Infostructure/"]
RUN dotnet restore "Services/Identity/Identity.Api/Identity.WebApi.csproj"
COPY . .
WORKDIR "/src/Services/Identity/Identity.Api"
RUN dotnet build "Identity.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identity.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.WebApi.dll"]
