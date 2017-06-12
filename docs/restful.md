Building RESTful Web Services
=============================

We can expose simple REST web services with the help of the combinator `mapJson`. The `mapJson` uses the default BCL JSON serializer `DataContractJsonSerializer`.


    open Suave
    open Suave.Json
    open System.Runtime.Serialization

    [<DataContract>]
    type Foo =
      { [<field: DataMember(Name = "foo")>]
        foo : string }

    [<DataContract>]
    type Bar =
      { [<field: DataMember(Name = "bar")>]
        bar : string }

    startWebServer defaultConfig (mapJson (fun (a:Foo) -> { bar = a.foo }))

<br/>

    [lang=bash]
    ademar@nascio:~$ curl -X POST -d '{"foo":"xyz"}' http://localhost:8083/ -w "\n"
    {"bar":"xyz"}

Or you can bring your own JSON serializer like Chiron:https://github.com/xyncro/chiron


    type A = 
      { a : int }
      static member ToJson (x : A) =
        Json.writer "a" x.a

<br/>

    [lang=bash]
    Json.format (Json.serialize { a = 42 })
    val it = """{"a":42}"""
    
<br/>

    let app =
      GET >=> path "/test"
      >=> OK (UTF8.bytes it)
      >=> setMimeType "application/json; charset=utf-8"