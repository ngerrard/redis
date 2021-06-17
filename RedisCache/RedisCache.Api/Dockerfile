#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["RedisCache.Api/RedisCache.Api.csproj", "RedisCache.Api/"]
RUN dotnet restore "RedisCache.Api/RedisCache.Api.csproj"
COPY . .
WORKDIR "/src/RedisCache.Api"
RUN dotnet build "RedisCache.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RedisCache.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RedisCache.Api.dll"]