# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY Exceptions/Exceptions.csproj ./Exceptions/
COPY API/API.csproj ./API/
COPY DAL/DAL.csproj ./DAL/
COPY Logic/Logic.csproj ./Logic/
COPY SharedObjects/SharedObjects.csproj ./SharedObjects/
RUN dotnet restore "./API/API.csproj"

# Copy everything else and build
COPY Exceptions/ ./Exceptions/
COPY API/ ./API/
COPY DAL/ ./DAL/
COPY Logic/ ./Logic/
COPY SharedObjects/ ./SharedObjects/
RUN dotnet build "./API/API.csproj" -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
RUN dotnet publish "./API/API.csproj" -c Release -o /app/publish

# Stage 3: Finalize
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]