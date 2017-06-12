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
] |> List.iter processMardown
