FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DWD.SolidPrinciples/DWD.SolidPrinciples.csproj", "DWD.SolidPrinciples/"]
RUN dotnet restore "DWD.SolidPrinciples/DWD.SolidPrinciples.csproj"
COPY . .
WORKDIR "/src/DWD.SolidPrinciples"
RUN dotnet build "DWD.SolidPrinciples.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DWD.SolidPrinciples.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DWD.SolidPrinciples.dll"]
