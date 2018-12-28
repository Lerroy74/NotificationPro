FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["NotificationPro/NotificationPro.csproj", "NotificationPro/"]
RUN dotnet restore "NotificationPro/NotificationPro.csproj"
COPY . .
WORKDIR "/src/NotificationPro"
RUN dotnet build "NotificationPro.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NotificationPro.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NotificationPro.dll"]