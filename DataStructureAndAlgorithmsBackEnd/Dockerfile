FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 1100
EXPOSE 1110

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DataStructureAndAlgorithmsBackEnd.csproj", "./"]
RUN dotnet restore "DataStructureAndAlgorithmsBackEnd.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "DataStructureAndAlgorithmsBackEnd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataStructureAndAlgorithmsBackEnd.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataStructureAndAlgorithmsBackEnd.dll"]
