FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Edgee.Api.VutbuCore/Edgee.Api.VutbuCore.csproj", "Edgee.Api.VutbuCore/"]
RUN dotnet restore "Edgee.Api.VutbuCore/Edgee.Api.VutbuCore.csproj"
COPY . .
WORKDIR "/src/Edgee.Api.VutbuCore"
RUN dotnet build "Edgee.Api.VutbuCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Edgee.Api.VutbuCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Edgee.Api.VutbuCore.dll"]