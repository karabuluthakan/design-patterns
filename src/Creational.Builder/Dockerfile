FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Creational.Builder/Creational.Builder.csproj", "Creational.Builder/"]
RUN dotnet restore "src/Creational.Builder/Creational.Builder.csproj"
COPY . .
WORKDIR "/src/Creational.Builder"
RUN dotnet build "Creational.Builder.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Creational.Builder.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Creational.Builder.dll"]
