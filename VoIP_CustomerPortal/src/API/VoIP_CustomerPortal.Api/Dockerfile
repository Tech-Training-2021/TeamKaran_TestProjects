#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/API/VoIP_CustomerPortal.Api/VoIP_CustomerPortal.Api.csproj", "src/API/VoIP_CustomerPortal.Api/"]
COPY ["src/Infrastructure/VoIP_CustomerPortal.Infrastructure/VoIP_CustomerPortal.Infrastructure.csproj", "src/Infrastructure/VoIP_CustomerPortal.Infrastructure/"]
COPY ["src/Core/VoIP_CustomerPortal.Application/VoIP_CustomerPortal.Application.csproj", "src/Core/VoIP_CustomerPortal.Application/"]
COPY ["src/Core/VoIP_CustomerPortal.Domain/VoIP_CustomerPortal.Domain.csproj", "src/Core/VoIP_CustomerPortal.Domain/"]
COPY ["src/Infrastructure/VoIP_CustomerPortal.Identity/VoIP_CustomerPortal.Identity.csproj", "src/Infrastructure/VoIP_CustomerPortal.Identity/"]
COPY ["src/Infrastructure/VoIP_CustomerPortal.Persistence/VoIP_CustomerPortal.Persistence.csproj", "src/Infrastructure/VoIP_CustomerPortal.Persistence/"]
RUN dotnet restore "src/API/VoIP_CustomerPortal.Api/VoIP_CustomerPortal.Api.csproj"
COPY . .
WORKDIR "/src/src/API/VoIP_CustomerPortal.Api"
RUN dotnet build "VoIP_CustomerPortal.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VoIP_CustomerPortal.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VoIP_CustomerPortal.Api.dll"]
