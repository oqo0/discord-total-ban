FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DiscordTotalBan/DiscordTotalBan.csproj", "DiscordTotalBan/"]
RUN dotnet restore "DiscordTotalBan/DiscordTotalBan.csproj"
COPY . .
WORKDIR "/src/DiscordTotalBan"
RUN dotnet build "DiscordTotalBan.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DiscordTotalBan.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiscordTotalBan.dll"]
