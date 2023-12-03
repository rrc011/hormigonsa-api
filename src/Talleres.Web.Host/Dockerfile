FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/Talleres.Web.Host/Talleres.Web.Host.csproj", "src/Talleres.Web.Host/"]
COPY ["src/Talleres.Web.Core/Talleres.Web.Core.csproj", "src/Talleres.Web.Core/"]
COPY ["src/Talleres.Application/Talleres.Application.csproj", "src/Talleres.Application/"]
COPY ["src/Talleres.Core/Talleres.Core.csproj", "src/Talleres.Core/"]
COPY ["src/Talleres.EntityFrameworkCore/Talleres.EntityFrameworkCore.csproj", "src/Talleres.EntityFrameworkCore/"]
WORKDIR "/src/src/Talleres.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/Talleres.Web.Host", "src/Talleres.Web.Host"]
COPY ["src/Talleres.Web.Core", "src/Talleres.Web.Core"]
COPY ["src/Talleres.Application", "src/Talleres.Application"]
COPY ["src/Talleres.Core", "src/Talleres.Core"]
COPY ["src/Talleres.EntityFrameworkCore", "src/Talleres.EntityFrameworkCore"]
WORKDIR "/src/src/Talleres.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Talleres.Web.Host.dll"]
