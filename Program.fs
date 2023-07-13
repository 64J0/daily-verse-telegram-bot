open Bot.Verse
open Bot.Telegram

[<EntryPoint>]
let main (_args: string[]) : int =
    let verse = getVerse ()
    let trimmedVerse = verse.Trim()

    let t = sendVerseToTelegram (trimmedVerse)
    t.Wait()

    0
