FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env


WORKDIR ./app

COPY .  .

EXPOSE 1300

RUN dotnet restore

#CMD dotnet run

ENTRYPOINT ["dotnet", "run"]