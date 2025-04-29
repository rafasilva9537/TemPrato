# TODO: improve security (configure user)

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY RecipesApi.csproj .
RUN dotnet restore
COPY . .

FROM build AS development
CMD ["dotnet", "watch", "run", "--no-launch-profile"]

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS production
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "RecipesApi.dll" ]