FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Behavioral.MediatorPattern/Behavioral.MediatorPattern.csproj", "Behavioral.MediatorPattern/"]
RUN dotnet restore "src/Behavioral.MediatorPattern/Behavioral.MediatorPattern.csproj"
COPY . .
WORKDIR "/src/Behavioral.MediatorPattern"
RUN dotnet build "Behavioral.MediatorPattern.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Behavioral.MediatorPattern.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Behavioral.MediatorPattern.dll"]
