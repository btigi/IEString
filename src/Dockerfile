# See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR sql

## Docker will cache the image when using this approach, meaning we won't get the latest commit from git
# RUN apt-get update && apt-get install -y git
# RUN git clone https://github.com/btigi/tlktosql.git
# RUN cd ..
# RUN dotnet build "/sql/tlktosql/src/TlkToSql.csproj" -c Release -o /sql/build

## Docker will always run an ADD and invalidate the cache for each command after it
ADD "https://github.com/btigi/tlktosql/archive/refs/heads/master.tar.gz" master.tar.gz
RUN tar -xf master.tar.gz
RUN dotnet build "/sql/tlktosql-master/src/TlkToSql.csproj" -c Release -o /sql/build

RUN cd /
RUN /sql/build/TlkToSql /sql/build/Resources/bg.tlk bg
RUN /sql/build/TlkToSql /sql/build/Resources/bg2.tlk bg2
RUN /sql/build/TlkToSql /sql/build/Resources/bg2ee.tlk bg2ee
RUN /sql/build/TlkToSql /sql/build/Resources/bgee.tlk bgee
RUN /sql/build/TlkToSql /sql/build/Resources/iwdee.tlk iwdee
RUN /sql/build/TlkToSql /sql/build/Resources/pst.tlk pst
RUN /sql/build/TlkToSql /sql/build/Resources/pstee.tlk pstee
RUN /sql/build/TlkToSql /sql/build/Resources/sod.tlk sod

WORKDIR /src
COPY ["IEString/IEString.csproj", "IEString/"]
RUN dotnet restore "IEString/IEString.csproj"
COPY . .
WORKDIR "/src/IEString"
RUN dotnet build "IEString.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IEString.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /sql/iedata.sqlite ./Resources
ENTRYPOINT ["dotnet", "IEString.dll"]