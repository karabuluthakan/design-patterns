FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Behavioral.ChainOfResponsibility/Behavioral.ChainOfResponsibility.csproj", "Behavioral.ChainOfResponsibility/"]
RUN dotnet restore "src/Behavioral.ChainOfResponsibility/Behavioral.ChainOfResponsibility.csproj"
COPY . .
WORKDIR "/src/Behavioral.ChainOfResponsibility"
RUN dotnet build "Behavioral.ChainOfResponsibility.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Behavioral.ChainOfResponsibility.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Behavioral.ChainOfResponsibility.dll"]
