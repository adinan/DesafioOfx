FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["./DesafioOfx.Api/DesafioOfx.Api.csproj", "DesafioOfx.Api/"]
COPY ["./DesafioOfx.Application/DesafioOfx.Application.csproj", "DesafioOfx.Application/"]
COPY ["./DesafioOfx.Core/DesafioOfx.Core.csproj", "DesafioOfx.Core/"]
COPY ["./DesafioOfx.Data/DesafioOfx.Data.csproj", "DesafioOfx.Data/"]
COPY ["./DesafioOfx.Domain/DesafioOfx.Domain.csproj", "DesafioOfx.Domain/"]

RUN dotnet restore "DesafioOfx.Api/DesafioOfx.Api.csproj"
COPY . .
WORKDIR "DesafioOfx.Api"
RUN dotnet build "DesafioOfx.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesafioOfx.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioOfx.Api.dll"]

RUN mkdir -p ofxFiles


RUN echo WARNING >&2 "\n\nAguarde 60 segundos para que Banco de dados sejá criado e populado\n\n"
