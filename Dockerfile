FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ENV ASPNETCORE_ENVIRONMENT=Docker
EXPOSE 80
#EXPOSE 443
#EXPOSE 8000
#EXPOSE 44348

WORKDIR /app 

COPY *.sln .
COPY FlatBot.WebApi/*.csproj ./FlatBot.WebApi/
COPY FlatBot.Application/*.csproj ./FlatBot.Application/
COPY FlatBot.Domain/*.csproj ./FlatBot.Domain/
COPY FlatBot.Infrastructure/*.csproj ./FlatBot.Infrastructure/ 
COPY FlatBot.Persistance/*.csproj ./FlatBot.Persistance/ 

RUN dotnet restore 

COPY FlatBot.WebApi/. ./FlatBot.WebApi/
COPY FlatBot.Application/. ./FlatBot.Application/
COPY FlatBot.Domain/. ./FlatBot.Domain/ 
COPY FlatBot.Infrastructure/. ./FlatBot.Infrastructure/ 
COPY FlatBot.Persistance/. ./FlatBot.Persistance/ 

WORKDIR /app/FlatBot.WebApi
RUN dotnet publish -c Release -o out 

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app 

COPY --from=build /app/FlatBot.WebApi/out ./
ENTRYPOINT ["dotnet", "FlatBot.WebApi.dll"]