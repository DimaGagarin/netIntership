#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Basket/Basket.WebApi/Basket.WebApi.csproj", "Services/Basket/Basket.WebApi/"]
COPY ["Services/Basket/Basket.Application/Basket.Application.csproj", "Services/Basket/Basket.Application/"]
COPY ["Services/Basket/Basket.Infostructure/Basket.Infostructure.csproj", "Services/Basket/Basket.Infostructure/"]
COPY ["Services/Basket/Basket.Domain/Basket.Domain.csproj", "Services/Basket/Basket.Domain/"]
RUN dotnet restore "Services/Basket/Basket.WebApi/Basket.WebApi.csproj"
COPY . .
WORKDIR "/src/Services/Basket/Basket.WebApi"
RUN dotnet build "Basket.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Basket.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Basket.WebApi.dll"]