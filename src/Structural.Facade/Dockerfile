FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Structural.Facade/Structural.Facade.csproj", "Structural.Facade/"]
RUN dotnet restore "src/Structural.Facade/Structural.Facade.csproj"
COPY . .
WORKDIR "/src/Structural.Facade"
RUN dotnet build "Structural.Facade.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Structural.Facade.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Structural.Facade.dll"]
