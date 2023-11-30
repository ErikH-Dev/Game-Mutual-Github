# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy solution files and restore dependencies
COPY ["GameMutualProject/GameMutualAPI/GameMutualAPI.csproj", "GameMutualProject/GameMutualAPI/"]
COPY ["GameMutualProject/Logic/Logic.csproj", "GameMutualProject/Logic/"]

# Change working directory to where the solution file is located
WORKDIR "/src/GameMutualProject"

RUN dotnet restore "GameMutualAPI/GameMutualAPI.csproj"

# Copy the rest of the application code excluding the front-end folder
COPY ["GameMutualProject/GameMutualAPI", "/src/GameMutualProject/GameMutualAPI/"]
COPY ["GameMutualProject/Logic", "/src/GameMutualProject/Logic/"]

# Build the application
WORKDIR "/src/GameMutualProject/GameMutualAPI"
RUN dotnet build "GameMutualAPI.csproj" -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
WORKDIR "/src/GameMutualProject/GameMutualAPI"
RUN dotnet publish "GameMutualAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Final
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "GameMutualAPI.dll"]