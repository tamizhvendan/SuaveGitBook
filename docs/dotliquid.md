Suave.DotLiquid
===============

Installing DotLiquid
--------------------
    
    [lang=bash]
    paket add nuget DotLiquid
    paket add nuget Suave.DotLiquid

How to use liquid from Suave.
-----------------------------

    open Suave
    open Suave.DotLiquid
    open DotLiquid

    type Model =
      { title : string }

    setTemplatesDirectory "./templates"

    let o = { title = "Hello World" }

    let app =
      choose
        [ GET >=> choose
            [ path "/" >=> page "my_page.liquid" o ]]


Then, for your template:

    [lang=html]
    <html>
      <head>
        <title>{{ model.title }}</title>
      </head>
      <body>
        <p>Hello from {{ model.title }}!</p>
      </body>
    </html>

Naming conventions
--------------------

Suave.DotLiquid sets the DotLiquid naming convention to Ruby by default. This means that if, for example, your model is a record type with a member called 'Name', DotLiquid would expect the binding to be '{% raw %}{{model.name}}{% endraw %}'. You can change the naming convention to C#:


    DotLiquid.setCSharpNamingConvention()

Working with Options
--------------------

DotLiquid can handle option types.

Example 1:

    type UserModel = {
        UserName: string option
    }

    let model = { UserName = Some "Dave" }
    // or
    let model = { UserName = None }

    let home = page "Index.html" model


<br />

    [lang=csharp]
    <div>
        {% if model.UserName %}
            Hello {{model.UserName.Value}}
        {% else %}
            Dave is not here
        {% endif %}
    </div>

Example 2:

    let model = Some "Dave"
    // or
    let model : string option = None

    let home = page "Index.html" model


<br />

    [lang=csharp]
    <div>
      {% if model %}
          Hello {{model.Value}}
      {% else %}
          Dave is not here
      {% endif %}
    </div>

References
----------

 - [DotLiquid for Designers](https://github.com/dotliquid/dotliquid/wiki/DotLiquid-for-Designers)
 - [DotLiquid for Developers](https://github.com/dotliquid/dotliquid/wiki/DotLiquid-for-Developers)