FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/ApiStorageManager/ApiStorageManager.WebApi/ApiStorageManager.WebApi.csproj", "src/ApiStorageManager/ApiStorageManager.WebApi/"]
COPY ["src/ApiStorageManager/ApiStorageManager.CrossCutting/ApiStorageManager.CrossCutting.csproj", "src/ApiStorageManager/ApiStorageManager.CrossCutting/"]
COPY ["src/ApiStorageManager/ApiStorageManager.Application/ApiStorageManager.Application.csproj", "src/ApiStorageManager/ApiStorageManager.Application/"]
COPY ["src/ApiStorageManager/ApiStorageManager.Domain/ApiStorageManager.Domain.csproj", "src/ApiStorageManager/ApiStorageManager.Domain/"]
COPY ["src/ApiStorageManager/ApiStorageManager.Infra/ApiStorageManager.Infra.csproj", "src/ApiStorageManager/ApiStorageManager.Infra/"]
RUN dotnet restore "src/ApiStorageManager/ApiStorageManager.WebApi/ApiStorageManager.WebApi.csproj"
COPY . .
WORKDIR "/src/src/ApiStorageManager/ApiStorageManager.WebApi"
RUN dotnet build "ApiStorageManager.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiStorageManager.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiStorageManager.WebApi.dll"]