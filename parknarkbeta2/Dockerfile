#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["parknarkbeta2/parknarkbeta2.csproj", "parknarkbeta2/"]
RUN dotnet restore "parknarkbeta2/parknarkbeta2.csproj"
COPY . .
WORKDIR "/src/parknarkbeta2"
RUN dotnet build "parknarkbeta2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "parknarkbeta2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "parknarkbeta2.dll"]