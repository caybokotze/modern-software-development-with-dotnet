FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CSharpAdvanced/CSharpAdvanced.csproj", "CSharpAdvanced/"]
RUN dotnet restore "CSharpAdvanced/CSharpAdvanced.csproj"
COPY . .
WORKDIR "/src/CSharpAdvanced"
RUN dotnet build "CSharpAdvanced.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSharpAdvanced.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSharpAdvanced.dll"]
