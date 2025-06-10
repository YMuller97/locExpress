FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR .

# Copy everything
#COPY . ./
# Restore as distinct layers
COPY ["./LocExpressApi.csproj", "LocExpressApi/"]
RUN dotnet restore "LocExpressApi/LocExpressApi.csproj"
# Build and publish a release
COPY [".", "LocExpressApi/"]
RUN dotnet build "LocExpressApi/LocExpressApi.csproj" -c Release -o /app/build
#RUN dotnet publish -o out

#RUN dotnet run Program.cs


#publish
FROM build as publish
RUN dotnet publish "LocExpressApi/LocExpressApi.csproj" -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocExpressApi.dll"]