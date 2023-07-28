#Set the base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Set up the SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebApplication_4.csproj", "./"]
RUN dotnet restore "./WebApplication_4.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "WebApplication_4.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "WebApplication_4.csproj" -c Release -o /app/publish

# Set up the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication_4.dll"]
