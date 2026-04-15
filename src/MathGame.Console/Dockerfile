# =============================================================================
# Stage 1: Build
# =============================================================================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set working directory.
WORKDIR /src

# Copy solution file first for layer caching.
COPY ["src/MathGame.sln", "."]

# Copy all project files for restore.
COPY ["src/MathGame/MathGame.csproj", "src/MathGame/"]
COPY ["src/MathGame.Data/MathGame.Data.csproj", "src/MathGame.Data/"]
COPY ["src/MathGame.Console/MathGame.Console.csproj", "src/MathGame.Console/"]

# Restore dependencies (cached until project files change).
RUN dotnet restore "src/MathGame.Console/MathGame.Console.csproj"

# Copy all remaining source code.
COPY . .

# Build and publish the application.
WORKDIR "/src/src/MathGame.Console"
RUN dotnet publish -c Release -o /app/publish --no-restore

# =============================================================================
# Stage 2: Runtime
# =============================================================================
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime

# Set working directory.
WORKDIR /app

# Copy published application from build stage.
COPY --from=build /app/publish .

# Set entry point to execute the console application.
ENTRYPOINT ["dotnet", "MathGame.Console.dll"]