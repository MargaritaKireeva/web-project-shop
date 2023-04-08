#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["ShopApp.WebPL/ShopApp.WebPL.csproj", "ShopApp.WebPL/"]
COPY ["ShopApp.BLL.Interfaces/ShopApp.BLL.Interfaces.csproj", "ShopApp.BLL.Interfaces/"]
COPY ["ShopApp.Entities/ShopApp.Entities.csproj", "ShopApp.Entities/"]
COPY ["ShopApp.TelegramMessage/ShopApp.TelegramBot.csproj", "ShopApp.TelegramMessage/"]
COPY ["ShopApp.BLL/ShopApp.BLL.csproj", "ShopApp.BLL/"]
COPY ["ShopApp.DAL.Interfaces/ShopApp.DAL.Interfaces.csproj", "ShopApp.DAL.Interfaces/"]
COPY ["ShopApp.DAL/ShopApp.DAL.csproj", "ShopApp.DAL/"]
RUN dotnet restore "ShopApp.WebPL/ShopApp.WebPL.csproj"
COPY . .
WORKDIR "/src/ShopApp.WebPL"
RUN dotnet build "ShopApp.WebPL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopApp.WebPL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopApp.WebPL.dll"]