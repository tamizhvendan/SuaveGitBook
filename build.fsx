#load @"./packages/FSharp.Formatting/FSharp.Formatting.fsx"

open System.IO
open FSharp.Literate

let writeToFile path content = File.WriteAllText(path, content)

let prependSuaveReference source =
  """
    [hide]
    #r "./packages/Suave/lib/net40/Suave.dll"
    open Suave
    open Suave.Filters
    open Suave.Operators
    open Suave.Successful
    open Suave.Files
    open Suave.RequestErrors
    open Suave.Logging

    // 

  """ + source

let replace (old : string) newTxt (text : string) =
  text.Replace(old,newTxt)

let processMardown (filePath, dest) =
  let tempFilePath = "./temp.md"

  filePath
  |> File.ReadAllText
  |> prependSuaveReference
  |> writeToFile tempFilePath

  Literate.ProcessMarkdown(tempFilePath, lineNumbers = false)

  "./temp.html"
  |> File.ReadAllText
  |> replace "<code " "<div "
  |> replace "</code></pre>" ("</div></pre>" + System.Environment.NewLine)
  |> writeToFile dest

  File.Delete tempFilePath
  File.Delete "./temp.html"

[
  "./docs/introduction.md", "./README.md"
  "./docs/routing.md", "./generated/routing.md"
  "./docs/async.md", "./generated/async.md"
  "./docs/async.md", "./generated/async.md"
  "./docs/composing.md", "./generated/composing.md"
  "./docs/combinators.md", "./generated/combinators.md"
  "./docs/fish.md", "./generated/fish.md"
  "./docs/restful.md", "./generated/restful.md"
  "./docs/typed.md", "./generated/typed.md"
  "./docs/binding.md", "./generated/binding.md"
  "./docs/api.md", "./generated/api.md"
  "./docs/sessions.md", "./generated/sessions.md"
  "./docs/files.md", "./generated/files.md"
  "./docs/dotliquid.md", "./generated/dotliquid.md"
  "./docs/heroku.md", "./generated/heroku.md"
  "./docs/azure-app-service.md", "./generated/azure-app-service.md"
  "./docs/logs.md", "./generated/logs.md"
  "./docs/paket.md", "./generated/paket.md"
  "./docs/websockets.md", "./generated/websockets.md"
] 
|> List.iter processMardown 
