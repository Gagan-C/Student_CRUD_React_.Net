# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project files and restore any dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code and build the application
COPY . ./
RUN dotnet publish -c Release -o out

# Use the official .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expose the port the app runs on
EXPOSE 5096

# Run the application
ENTRYPOINT ["dotnet", "Student API.dll"]