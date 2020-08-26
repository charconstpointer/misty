FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-focal AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-focal AS build

COPY [".", "app/"]
RUN ls -la app
RUN dotnet restore "app/Misty.csproj"
WORKDIR /src
COPY . .
RUN dotnet build "Misty.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Misty.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Misty.dll"]
