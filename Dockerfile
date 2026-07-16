# ============================================
# Build Stage
# ============================================

FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build

WORKDIR /src

# Copy solution
COPY OpenIddict.ReferenceServer.sln .

# Copy project files
COPY OpenIddict.Reference.Api/OpenIddict.Reference.Api.csproj OpenIddict.Reference.Api/
COPY OpenIddict.Reference.Application/OpenIddict.Reference.Application.csproj OpenIddict.Reference.Application/
COPY OpenIddict.Reference.Domain/OpenIddict.Reference.Domain.csproj OpenIddict.Reference.Domain/
COPY OpenIddict.Reference.Infrastructure/OpenIddict.Reference.Infrastructure.csproj OpenIddict.Reference.Infrastructure/
COPY OpenIddict.Reference.Persistence/OpenIddict.Reference.Persistence.csproj OpenIddict.Reference.Persistence/

# Restore dependencies
RUN dotnet restore OpenIddict.ReferenceServer.sln

# Copy everything else
COPY . .

# Publish
RUN dotnet publish OpenIddict.Reference.Api/OpenIddict.Reference.Api.csproj \
    --configuration Release \
    --output /app/publish \
    --no-restore \
    /p:UseAppHost=false


# ============================================
# Runtime Stage
# ============================================

FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS final

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet","OpenIddict.Reference.Api.dll"]