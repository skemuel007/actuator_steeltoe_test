#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
# EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ActuatorTest/ActuatorTest.csproj", "ActuatorTest/"]
RUN dotnet restore "ActuatorTest/ActuatorTest.csproj"
COPY . .
WORKDIR "/src/ActuatorTest"
RUN dotnet build "ActuatorTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ActuatorTest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ActuatorTest.dll"]
