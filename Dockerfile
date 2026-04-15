# =============================================================================
# Stage 1: Build
# =============================================================================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set working directory.
WORKDIR /src

# Copy all project files for restore.
COPY ["src/MathGame.Console/MathGame.Console.csproj", "src/MathGame.Console/"]
COPY ["src/MathGame/MathGame.csproj", "src/MathGame/"]
COPY ["src/MathGame.Data/MathGame.Data.csproj", "src/MathGame.Data/"]

# Restore dependencies (cached until project files change).
RUN dotnet restore "src/MathGame.Console/MathGame.Console.csproj"

# Copy all remaining source code.
COPY . .

# Build and publish the application.
WORKDIR "/src/src/MathGame.Console"
RUN dotnet publish "MathGame.Console.csproj" -c Release -o /app/publish --no-restore

# =============================================================================
# Stage 2: Runtime
# =============================================================================
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime

# Set working directory.
WORKDIR /app

# Copy published application from build stage.
COPY --from=build /app/publish .

# Set entry point to execute the console application.
# Usage: docker run mathgame:v1 -n <name> -q <questions> -d <difficulty>
ENTRYPOINT ["dotnet", "MathGame.Console.dll"]