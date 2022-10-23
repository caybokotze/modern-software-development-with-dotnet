FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CSharpBasics/CSharpBasics.csproj", "CSharpBasics/"]
RUN dotnet restore "CSharpBasics/CSharpBasics.csproj"
COPY . .
WORKDIR "/src/CSharpBasics"
RUN dotnet build "CSharpBasics.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSharpBasics.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSharpBasics.dll"]
