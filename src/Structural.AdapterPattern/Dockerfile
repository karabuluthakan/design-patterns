FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Structural.AdapterPattern/Structural.AdapterPattern.csproj", "Structural.AdapterPattern/"]
RUN dotnet restore "src/Structural.AdapterPattern/Structural.AdapterPattern.csproj"
COPY . .
WORKDIR "/src/Structural.AdapterPattern"
RUN dotnet build "Structural.AdapterPattern.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Structural.AdapterPattern.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Structural.AdapterPattern.dll"]
