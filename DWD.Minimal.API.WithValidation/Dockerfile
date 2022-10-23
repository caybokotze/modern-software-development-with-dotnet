FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Minimal.API.WithValidation/Minimal.API.WithValidation.csproj", "Minimal.API.WithValidation/"]
RUN dotnet restore "Minimal.API.WithValidation/Minimal.API.WithValidation.csproj"
COPY . .
WORKDIR "/src/Minimal.API.WithValidation"
RUN dotnet build "Minimal.API.WithValidation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Minimal.API.WithValidation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Minimal.API.WithValidation.dll"]
