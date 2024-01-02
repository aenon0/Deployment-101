# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy and restore the application projects
COPY Backend/Application/*.csproj ./Application/
COPY Backend/Infrastructure/*.csproj ./Infrastructure/
COPY Backend/Persistence/*.csproj ./Persistence/
COPY Backend/Domain/*.csproj ./Domain/
COPY Backend/WebApi/*.csproj ./WebApi/
RUN dotnet restore ./WebApi/*.csproj

# Copy the entire solution and build
COPY Backend .
RUN dotnet build -c Release --output ./build

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copy the publish output from the build stage
COPY --from=build /app/build ./build

# Set the entrypoint to start the application
ENTRYPOINT ["dotnet", "./build/WebApi.dll"]
