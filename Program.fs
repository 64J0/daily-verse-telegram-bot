open Bot.Versicle
open Bot.Telegram

[<EntryPoint>]
let main (_args: string[]) : int =
    let versicle = getVersicle ()
    let trimmedVersicle = versicle.Trim()

    let t = sendVersicleToTelegram (trimmedVersicle)
    t.Wait()

    0
