# Stage 1: Build the Angular Client
FROM node:18 AS client-build
WORKDIR /app/client
COPY client/package*.json ./
RUN npm install
COPY client/. .
RUN npm run build --prod

# Stage 2: Build the ASP.NET Core API
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS service-build
WORKDIR /app/service
COPY server/*.csproj ./
RUN dotnet restore
COPY server/. .
RUN dotnet publish -c Release -o out

# Stage 3: Combine and Serve Both
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy the Angular build output
COPY --from=client-build /app/client/dist/client/browser ./wwwroot

# Copy the ASP.NET Core API build output
COPY --from=service-build /app/service/out ./

# Expose the port for the API
EXPOSE 80

# Run the ASP.NET Core API
ENTRYPOINT ["dotnet", "Service.dll"]