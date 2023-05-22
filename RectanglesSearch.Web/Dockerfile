FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7104

ENV ASPNETCORE_URLS=http://+:7104

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RectanglesSearch.Web.csproj", "./"]
RUN dotnet restore "RectanglesSearch.Web.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "RectanglesSearch.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RectanglesSearch.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RectanglesSearch.Web.dll"]
