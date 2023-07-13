module Bot.Versicle

open FSharp.Data

[<Literal>]
let private BIBLIA_ON_URL = "https://www.bibliaon.com/versiculo_do_dia/"

type BibliaOn = HtmlProvider<BIBLIA_ON_URL>

let getVersicle () : string =
    BibliaOn().Html.Elements().CssSelect("#versiculo_hoje")
    |> List.map (fun t -> t.InnerText())
    |> List.fold (+) ""
