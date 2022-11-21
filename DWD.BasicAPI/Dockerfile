FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DWD.BasicAPI/DWD.BasicAPI.csproj", "DWD.BasicAPI/"]
RUN dotnet restore "DWD.BasicAPI/DWD.BasicAPI.csproj"
COPY . .
WORKDIR "/src/DWD.BasicAPI"
RUN dotnet build "DWD.BasicAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DWD.BasicAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DWD.BasicAPI.dll"]
