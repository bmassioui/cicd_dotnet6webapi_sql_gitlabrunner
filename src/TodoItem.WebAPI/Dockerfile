#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TodoItem.WebAPI/TodoItem.WebAPI.csproj", "src/TodoItem.WebAPI/"]
RUN dotnet restore "src/TodoItem.WebAPI/TodoItem.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/TodoItem.WebAPI"
RUN dotnet build "TodoItem.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TodoItem.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoItem.WebAPI.dll"]