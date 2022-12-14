FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PaymentProcessor.Api/PaymentProcessor.Api.csproj", "PaymentProcessor.Api/"]
RUN dotnet restore "PaymentProcessor.Api/PaymentProcessor.Api.csproj"
COPY . .
WORKDIR "/src/PaymentProcessor.Api"
RUN dotnet build "PaymentProcessor.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PaymentProcessor.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaymentProcessor.Api.dll"]
