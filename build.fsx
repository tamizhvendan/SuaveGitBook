#load @"./packages/FSharp.Formatting/FSharp.Formatting.fsx"

open System.IO
open FSharp.Literate

let writeToFile path content = File.WriteAllText(path, content)

let prependSuaveReference source =
  """
    [hide]
    #r "./packages/Suave/lib/net40/Suave.dll"

  """ + source

let replace (old : string) newTxt (text : string) =
  text.Replace(old,newTxt)

let processMardown filePath =
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
  |> writeToFile "README.md"

  File.Delete tempFilePath
  File.Delete "./temp.html"

processMardown "./docs/introduction.md"
