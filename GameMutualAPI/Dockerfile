# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["API/API.csproj", "./API/"]
COPY ["DAL/DAL.csproj", "./DAL/"]
COPY ["Logic/Logic.csproj", "./Logic/"]
COPY ["SharedObjects/SharedObjects.csproj", "./SharedObjects/"]
RUN dotnet restore "./API/API.csproj"

# Copy the rest of the application code
COPY ["API/", "./API/"]
COPY ["DAL/", "./DAL/"]
COPY ["Logic/", "./Logic/"]
COPY ["SharedObjects/", "./SharedObjects/"]

# Build the application
RUN dotnet build "./API/API.csproj" -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
RUN dotnet publish "./API/API.csproj" -c Release -o /app/publish

# Stage 3: Final
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "API.dll"]