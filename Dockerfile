# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out
    
# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:5.0	
WORKDIR /app
COPY --from=build /src/out .
ENTRYPOINT [ "dotnet", "WebApplication_4.dll" ]
