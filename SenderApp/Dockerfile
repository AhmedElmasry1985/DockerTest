FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

RUN apt-get update && apt-get install -y curl && curl -sSL https://get.docker.com/ | sh

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SenderApp/SenderApp.csproj", "SenderApp/"]
RUN dotnet restore "SenderApp/SenderApp.csproj"

COPY . .
WORKDIR "/src/SenderApp"
RUN dotnet build "SenderApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SenderApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SenderApp.dll"]
