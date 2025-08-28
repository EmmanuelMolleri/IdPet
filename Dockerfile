# Imagem base para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

# Porta que o Cloud Run vai usar
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development

# Imagem para build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copia apenas os csproj primeiro (para cache de dependências)
COPY ["IdPet.Api/IdPet.Api.csproj", "IdPet.Api/"]
COPY ["IdPet.ApplicationServices/IdPet.ApplicationServices.csproj", "IdPet.ApplicationServices/"]
COPY ["IdPet.CrossCutting/IdPet.CrossCutting.csproj", "IdPet.CrossCutting/"]
COPY ["IdPet.Domain/IdPet.Domain.csproj", "IdPet.Domain/"]
COPY ["IdPet.Infra.Data/IdPet.Infra.Data.csproj", "IdPet.Infra.Data/"]
COPY ["IdPet.Infra.Gateway/IdPet.Infra.Gateway.csproj", "IdPet.Infra.Gateway/"]

# Restaura as dependências
RUN dotnet restore "IdPet.Api/IdPet.Api.csproj"

# Copia todo o código agora
COPY . .

WORKDIR "/src/IdPet.Api"
RUN dotnet build "IdPet.Api.csproj" -c Release -o /app/build

# Publicação
FROM build AS publish
RUN dotnet publish "IdPet.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "IdPet.Api.dll"]
