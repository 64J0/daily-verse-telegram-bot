module Bot.Telegram

open System
open System.Threading.Tasks

open Telegram.Bot
open Telegram.Bot.Types

// Find the chatId:
// https://gist.github.com/zapisnicar/247d53f8e3980f6013a221d8c7459dc3
let private CHAT_ID = Environment.GetEnvironmentVariable "CHAT_ID"

let private TELEGRAM_API_TOKEN =
    Environment.GetEnvironmentVariable "TELEGRAM_API_TOKEN"

let private bot = new TelegramBotClient(TELEGRAM_API_TOKEN)

let sendVerseToTelegram (verse: string) : Task<Message> =
    bot.SendTextMessageAsync(CHAT_ID, verse)
