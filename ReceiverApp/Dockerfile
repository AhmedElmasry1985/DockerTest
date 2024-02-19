FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ReceiverApp/ReceiverApp.csproj", "ReceiverApp/"]
RUN dotnet restore "ReceiverApp/ReceiverApp.csproj"
COPY . .
WORKDIR "/src/ReceiverApp"
RUN dotnet build "ReceiverApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReceiverApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReceiverApp.dll"]