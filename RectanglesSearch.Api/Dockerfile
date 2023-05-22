FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7184

ENV ASPNETCORE_URLS=http://+:7184

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RectanglesSearch.Api.csproj", "./"]
RUN dotnet restore "RectanglesSearch.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "RectanglesSearch.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RectanglesSearch.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RectanglesSearch.Api.dll"]
