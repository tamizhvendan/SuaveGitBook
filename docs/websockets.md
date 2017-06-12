Realtime Messages With WebSockets
=================================

It's easy to set up WebSockets with Suave.

First, define a function that takes `WebSocket` and `HttpContext` typed parameters, and returns a socket computation expression:

    open Suave.Sockets
    open Suave.Sockets.Control
    open Suave.WebSocket

    let ws (webSocket : WebSocket) (context: HttpContext) =
        socket {
          ...
        }

Next, use the `read` and `send` function to receive and send messages to the clients:

    socket {
        let mutable loop = true

        while loop do
            let! msg = webSocket.read()

            match msg with
            | (Text, data, true) ->
                let str = UTF8.toString data
                let response = sprintf "response to %s" str
                let byteResponse =
                    response
                    |> System.Text.Encoding.ASCII.GetBytes
                    |> ByteSegment
                do! webSocket.send Text byteResponse true

            | (Close, _, _) ->
                let emptyResponse = [||] |> ByteSegment
                do! webSocket.send Close emptyResponse true
                loop <- false

            | _ -> ()
      }

Then, use the `handShake` function to fit it in your web server:

    let app : WebPart =
        choose [
          path "/websocket" >=> handShake ws
          GET >=> choose [ path "/" >=> file "index.html"; browseHome ]
          NOT_FOUND "Found no handlers." ]

The complete example can be found [here](https://github.com/SuaveIO/suave/tree/master/examples/WebSocket).

Handling connection errors
---------------------------------

By default the socket computation expression handles any errors transparently on both writing and reading from the websocket shutting down the connection.

You may want to add your own additional error handling logic to catch and handle any errors raised when reading and writing from a websocket. Some scenarios where this may be useful:

- Alerting the rest of the application that a connection is closed.
- Unsubscribing and/or shutting down processes used by the websocket connection.
- Custom logging of the error.

Example code can be found [here](https://github.com/SuaveIO/suave/tree/master/examples/WebSocket).