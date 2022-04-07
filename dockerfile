#FROM bitnami/dotnet-skd
#FROM bitnami/dotnet-sdk
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
#FROM mcr.microsoft.com/dotnet/nightly/sdk:5.0
#FROM mcr.microsoft.com/dotnet/sdk:5.0
#FROM mcr.microsoft.com/dotnet/aspnet:5.0

WORKDIR ./app

COPY .  .

EXPOSE 1300

RUN dotnet restore

#CMD dotnet run

ENTRYPOINT ["dotnet", "run"]