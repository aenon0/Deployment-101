# Build stage
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /app

# Copy and restore the application projects
COPY backend2/Application/*.csproj ./Application/
COPY backend2/Infrastructure/*.csproj ./Infrastructure/
COPY backend2/Persistence/*.csproj ./Persistence/
COPY backend2/Domain/*.csproj ./Domain/
COPY backend2/WebApi/*.csproj ./WebApi/
RUN dotnet restore ./WebApi/*.csproj

# Copy the entire solution and build
COPY backend2 .
RUN dotnet build -c Release --output ./build

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS runtime
WORKDIR /app

# Copy the publish output from the build stage
COPY --from=build /app/build ./build

# Set the entrypoint to start the application
ENTRYPOINT ["dotnet", "./build/WebApi.dll"]
