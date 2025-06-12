FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
#WORKDIR .
WORKDIR /src

COPY ["LocExpressApi.csproj", "LocExpressApi/"]
WORKDIR /src/LocExpressApi
RUN dotnet restore

COPY . .
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish




# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
ENV ASPNETCORE_HTTP_PORTS=5000
EXPOSE 5000
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "LocExpressApi.dll"]