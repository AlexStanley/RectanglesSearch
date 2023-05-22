FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7240

ENV ASPNETCORE_URLS=http://+:7240

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RectanglesSearch.Api.Identity.csproj", "./"]
RUN dotnet restore "RectanglesSearch.Api.Identity.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "RectanglesSearch.Api.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RectanglesSearch.Api.Identity.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RectanglesSearch.Api.Identity.dll"]
