#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TodoApp.API/TodoApp.API.csproj", "TodoApp.API/"]
COPY ["TodoApp.Service/TodoApp.Service.csproj", "TodoApp.Service/"]
COPY ["TodoApp.Repository/TodoApp.Repository.csproj", "TodoApp.Repository/"]
COPY ["TodoApp.Core/TodoApp.Core.csproj", "TodoApp.Core/"]
RUN dotnet restore "TodoApp.API/TodoApp.API.csproj"
COPY . .
WORKDIR "/src/TodoApp.API"
RUN dotnet build "TodoApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TodoApp.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoApp.API.dll"]