# ---------- Stage 1: Build ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj from the project subfolder (better layer caching)
COPY AdvancedAirAPI/AdvancedAirAPI.csproj ./AdvancedAirAPI/
RUN dotnet restore ./AdvancedAirAPI/AdvancedAirAPI.csproj

# Copy everything else and build
COPY . ./
RUN dotnet publish ./AdvancedAirAPI/AdvancedAirAPI.csproj -c Release -o /app/publish /p:UseAppHost=false

# ---------- Stage 2: Runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

# Use Render's PORT if set, otherwise default to 8080
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}
EXPOSE 8080

ENTRYPOINT ["dotnet", "AdvancedAirAPI.dll"]
