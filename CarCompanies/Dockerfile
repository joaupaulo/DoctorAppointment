﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CarCompanies/CarCompanies.csproj", "CarCompanies/"]
RUN dotnet restore "CarCompanies/CarCompanies.csproj"
COPY . .
WORKDIR "/src/CarCompanies"
RUN dotnet build "CarCompanies.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarCompanies.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarCompanies.dll"]
