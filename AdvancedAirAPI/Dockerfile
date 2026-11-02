# ===== Build Stage =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj first to leverage caching
COPY ["*.csproj", "./"]
RUN dotnet restore

# Copy all remaining files and publish
COPY . .
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# ===== Runtime Stage =====
# Use the standard aspnet image (not Alpine) to avoid globalization issues with Npgsql
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published output
COPY --from=build /app/publish .

# Critical: Render will inject the PORT environment variable, your Program.cs is already reading it
# But the Dockerfile needs to declare the default port for EXPOSE (optional, mainly for documentation)
# Ensure the app listens on 0.0.0.0 and the dynamically assigned port
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

# Optional: health check (if curl is available in the image; if not, you can omit it, Render will rely on PORT detection)
# HEALTHCHECK --interval=30s --timeout=10s --start-period=20s --retries=3 \
#     CMD curl -f http://localhost:8080/health || exit 1

ENTRYPOINT ["dotnet", "AdvancedAirAPI.dll"]
