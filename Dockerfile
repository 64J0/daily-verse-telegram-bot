FROM mcr.microsoft.com/dotnet/sdk:7.0-jammy as build

ENV CHAT_ID="changeme"
ENV TELEGRAM_API_TOKEN="changeme"

WORKDIR /app

COPY . .

RUN dotnet restore "DailyVerseTelegramBot.fsproj"

RUN dotnet publish "DailyVerseTelegramBot.fsproj" \
    --self-contained false \
    --no-restore\
    -c Release \
    -o /app/publish

FROM mcr.microsoft.com/dotnet/nightly/runtime:7.0-jammy-chiseled

LABEL org.opencontainers.image.source=https://github.com/64J0/daily-verse-telegram-bot

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["./DailyVerseTelegramBot"]
