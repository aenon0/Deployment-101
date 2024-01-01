# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy and restore the application projects
COPY ../Application/*.csproj ./Application/
COPY ../Infrastructure/*.csproj ./Infrastructure/
COPY ../Persistence/*.csproj ./Persistence/
COPY ../Domain/*.csproj ./Domain/
RUN dotnet restore ../*.csproj

# Copy the entire solution and build
COPY . .
RUN dotnet build -c Release

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copy the publish output from the build stage
COPY --from=build /app/Application/bin/Release/net7.0/publish ./Application
COPY --from=build /app/Infrastructure/bin/Release/net7.0/publish ./Infrastructure
COPY --from=build /app/Persistence/bin/Release/net7.0/publish ./Persistence
COPY --from=build /app/Domain/bin/Release/net7.0/publish ./Domain

# Set the entrypoint to start the application
ENTRYPOINT ["dotnet", "."]
