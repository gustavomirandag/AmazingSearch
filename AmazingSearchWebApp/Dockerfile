FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["AmazingSearchWebApp/AmazingSearchWebApp.csproj", "AmazingSearchWebApp/"]
RUN dotnet restore "AmazingSearchWebApp/AmazingSearchWebApp.csproj"
COPY . .
WORKDIR "/src/AmazingSearchWebApp"
RUN dotnet build "AmazingSearchWebApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AmazingSearchWebApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AmazingSearchWebApp.dll"]