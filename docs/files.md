Serving static files, HTTP Compression and MIME types
=====================================================

A typical static file serving Suave application would look somewhat like this,
placed in `files.fsx` and serving from `./public` relative to your script file.


    #!/usr/bin/env fsharpi
    #r "./packages/Suave/lib/net40/Suave.dll"
    open System.IO
    open Suave
    open Suave.Filters
    open Suave.Operators
    let app : WebPart =
      choose [
        GET >=> path "/" >=> Files.file "index.html"
        GET >=> Files.browseHome
        RequestErrors.NOT_FOUND "Page not found." 
      ]
    let config =
      { defaultConfig with homeFolder = Some (Path.GetFullPath "./public") }

    startWebServer config app

The main file combinators are `file`, `browseHome` and variations of these. To
learn about all of them check out the Files module
[documentation](https://suave.io/Suave.html#def:module%20Suave.Files)

`file` will take the relative or absolute path for the file we want to serve to
the client. It will set MIME-type headers based on the file extension.

`browseHome` will match existing files in the `homeFolder` based on the `Url`
property and will serve them via the `file` combinator; `homeFolder` is a
configuration parameter and can be set in the configuration record.

    startWebServer { defaultConfig with homeFolder = Some @"C:\MyFiles" } app

Suave supports **gzip** and **deflate** http compression encodings. Http
compression is configured via the MIME types map in the server configuration
record.

By default Suave does not serve files with extensions not registered in
the mime types map.

The default mime types map `defaultMimeTypesMap` looks like this.


    let defaultMimeTypesMap = function
      | ".css" -> createMimeType "text/css" true
      | ".gif" -> createMimeType "image/gif" false
      | ".png" -> createMimeType "image/png" false
      | ".htm"
      | ".html" -> createMimeType "text/html" true
      | ".jpe"
      | ".jpeg"
      | ".jpg" -> createMimeType "image/jpeg" false
      | ".js"  -> createMimeType "application/x-javascript" true
      // ... some stuff left out
      | _      -> None

You can register additional MIME extensions by creating a new mime map in the following fashion.


    // Adds a new mime type to the default map
    let mimeTypes =
      defaultMimeTypesMap
        @@ (function | ".avi" -> createMimeType "video/avi" false | _ -> None)

    let webConfig = { defaultConfig with mimeTypesMap = mimeTypes }