FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["ShubraRanjanAPI.csproj", "./"]
RUN dotnet restore "ShubraRanjanAPI.csproj"

COPY . .
RUN dotnet publish "ShubraRanjanAPI.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "ShubraRanjanAPI.dll"]