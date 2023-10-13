FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Behavioral.Visitor/Behavioral.Visitor.csproj", "src/Behavioral.Visitor/"]
RUN dotnet restore "src/Behavioral.Visitor/Behavioral.Visitor.csproj"
COPY . .
WORKDIR "/src/src/Behavioral.Visitor"
RUN dotnet build "Behavioral.Visitor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Behavioral.Visitor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Behavioral.Visitor.dll"]
