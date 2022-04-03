#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FlatBot.WebApi/FlatBot.WebApi.csproj", "FlatBot.WebApi/"]
COPY ["FlatBot.Infrastructure/FlatBot.Infrastructure.csproj", "FlatBot.Infrastructure/"]
COPY ["FlatBot.Application/FlatBot.Application.csproj", "FlatBot.Application/"]
COPY ["FlatBot.Domain/FlatBot.Domain.csproj", "FlatBot.Domain/"]
COPY ["FlatBot.Persistance/FlatBot.Persistance.csproj", "FlatBot.Persistance/"]
RUN dotnet restore "FlatBot.WebApi/FlatBot.WebApi.csproj"
COPY . .
WORKDIR "/src/FlatBot.WebApi"
RUN dotnet build "FlatBot.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FlatBot.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FlatBot.WebApi.dll"]
