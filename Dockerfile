#Set the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out
    
    
# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /src/out .
ENTRYPOINT [ "dotnet", "WebApplication_4.dll" ]
