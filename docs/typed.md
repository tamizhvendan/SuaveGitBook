Typed routes
============

    let testapp : WebPart =
      choose
        [ pathScan "/add/%d/%d" (fun (a,b) -> OK((a + b).ToString()))
          NOT_FOUND "Found no handlers" ]