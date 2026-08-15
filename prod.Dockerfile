# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the .csproj file and restore dependencies
COPY ["ShubraRanjanAPI.csproj", "./"]
RUN dotnet restore "ShubraRanjanAPI.csproj"

# Copy the rest of the source code and build the application
COPY . .
RUN dotnet publish "ShubraRanjanAPI.csproj" -c Release -o /app/publish

# Use the official .NET runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose the port the application runs on
EXPOSE 8080

# Set the entry point for the container
ENTRYPOINT ["dotnet", "ShubraRanjanAPI.dll"]
