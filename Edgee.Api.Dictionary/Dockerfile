FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Edgee.Api.Dictionary/Edgee.Api.Dictionary.csproj", "Edgee.Api.Dictionary/"]
RUN dotnet restore "Edgee.Api.Dictionary/Edgee.Api.Dictionary.csproj"
COPY . .
WORKDIR "/src/Edgee.Api.Dictionary"
RUN dotnet build "Edgee.Api.Dictionary.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Edgee.Api.Dictionary.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Edgee.Api.Dictionary.dll"]