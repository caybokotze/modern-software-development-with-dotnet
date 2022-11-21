FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DWD.DependencyInjection/DWD.DependencyInjection.csproj", "DWD.DependencyInjection/"]
RUN dotnet restore "DWD.DependencyInjection/DWD.DependencyInjection.csproj"
COPY . .
WORKDIR "/src/DWD.DependencyInjection"
RUN dotnet build "DWD.DependencyInjection.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DWD.DependencyInjection.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DWD.DependencyInjection.dll"]
