#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["RibbonBotWebSite/RibbonBotWebSite.csproj", "RibbonBotWebSite/"]
RUN dotnet restore "RibbonBotWebSite/RibbonBotWebSite.csproj"
COPY . .
WORKDIR "/src/RibbonBotWebSite"
RUN dotnet build "RibbonBotWebSite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RibbonBotWebSite.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RibbonBotWebSite.dll"]