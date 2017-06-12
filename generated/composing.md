<h1>Composing bigger programs: combinators</h1>
<p>Defining the entire logic of your program in a single giant function called app would clearly be impossible. Functional programming is all about composing functions from several smaller functions, and both F# and Suave offer various tools to make this easy.</p>
<p>In functional programming parlance, a "combinator" either combines several things of the same type into another thing of the same type, or otherwise takes a value and returns a new, modified version of that value. In mathematics it has a slightly different meaning, but we need not worry about this. In the case of Suave, there are two types of combinator:</p>
<ul>
<li>Combinators which combine multiple <code>WebPart</code> into a single <code>WebPart</code>.</li>
<li>Combinators that produce <code>WebPart</code> from more primitive values. Recall that <code>WebPart</code> has the type <code>HttpContext -&gt; Async&lt;HttpContext option&gt;</code>. These combinators therefore always take a single HttpContext and produce a new HttpContext, wrapped inside an async option workflow.</li>
</ul>
<p>Together these are used to create web parts, combine them to produce new webparts, and ultimately combine them all into a single webpart passed as an argument used to initialise the web server.</p>
<p>We have already seen several examples of combinators. The <code>choose</code> function seen below takes a list of <code>WebPart</code>, and combines them all into a single new <code>WebPart</code>:</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">val</span> <span onmouseout="hideTip(event, 'fs1', 1)" onmouseover="showTip(event, 'fs1', 1)" class="i">choose</span> <span class="o">:</span> (<span class="i">options</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs2', 2)" onmouseover="showTip(event, 'fs2', 2)" class="i">WebPart</span> <span onmouseout="hideTip(event, 'fs3', 3)" onmouseover="showTip(event, 'fs3', 3)" class="i">list</span>) <span class="k">-&gt;</span> <span onmouseout="hideTip(event, 'fs2', 4)" onmouseover="showTip(event, 'fs2', 4)" class="i">WebPart</span>
</div></pre>

<p>The <code>choose</code> combinator is implemented such that it will execute each webpart in the list until one returns success.</p>
<p><code>&gt;=&gt;</code> is also a combinator, one that combines exactly two web parts. It runs the first, waits for it to finish, and then either passes the result into the second part, or short circuits if the first part returns <code>None</code>.</p>
<p><code>OK</code> is a combinator of the second type. It always succeeds and writes its argument to the underlying response stream. It has type <code>string -&gt; WebPart</code>.</p>
<p>To gain access to the underlying <code>HttpRequest</code> and read query and http form data we can use the <code>request</code> combinator (the <code>^^</code> custom operator is shorthand for searching a list of key-value option pairs and returning the value (or None if not found)):</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">let</span> <span class="i">greetings</span> <span class="i">q</span> <span class="o">=</span>
  <span onmouseout="hideTip(event, 'fs4', 5)" onmouseover="showTip(event, 'fs4', 5)" class="i">defaultArg</span> (<span onmouseout="hideTip(event, 'fs5', 6)" onmouseover="showTip(event, 'fs5', 6)" class="i">Option</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs6', 7)" onmouseover="showTip(event, 'fs6', 7)" class="i">ofChoice</span> (<span class="i">q</span> <span class="o">^^</span> <span class="s">&quot;name&quot;</span>)) <span class="s">&quot;World&quot;</span> <span class="o">|&gt;</span> <span onmouseout="hideTip(event, 'fs7', 8)" onmouseover="showTip(event, 'fs7', 8)" class="i">sprintf</span> <span class="s">&quot;Hello %s&quot;</span>

<span class="k">let</span> <span class="i">sample</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs2', 9)" onmouseover="showTip(event, 'fs2', 9)" class="i">WebPart</span> <span class="o">=</span> 
    <span onmouseout="hideTip(event, 'fs8', 10)" onmouseover="showTip(event, 'fs8', 10)" class="i">path</span> <span class="s">&quot;/hello&quot;</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs1', 11)" onmouseover="showTip(event, 'fs1', 11)" class="i">choose</span> [
      <span onmouseout="hideTip(event, 'fs9', 12)" onmouseover="showTip(event, 'fs9', 12)" class="i">GET</span>  <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs10', 13)" onmouseover="showTip(event, 'fs10', 13)" class="i">request</span> (<span class="k">fun</span> <span class="i">r</span> <span class="k">-&gt;</span> <span onmouseout="hideTip(event, 'fs11', 14)" onmouseover="showTip(event, 'fs11', 14)" class="i">OK</span> (<span class="i">greetings</span> <span class="i">r</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs12', 15)" onmouseover="showTip(event, 'fs12', 15)" class="i">query</span>))
      <span onmouseout="hideTip(event, 'fs13', 16)" onmouseover="showTip(event, 'fs13', 16)" class="i">POST</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs10', 17)" onmouseover="showTip(event, 'fs10', 17)" class="i">request</span> (<span class="k">fun</span> <span class="i">r</span> <span class="k">-&gt;</span> <span onmouseout="hideTip(event, 'fs11', 18)" onmouseover="showTip(event, 'fs11', 18)" class="i">OK</span> (<span class="i">greetings</span> <span class="i">r</span><span class="o">.</span><span class="i">form</span>))
      <span onmouseout="hideTip(event, 'fs14', 19)" onmouseover="showTip(event, 'fs14', 19)" class="i">RequestErrors</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs15', 20)" onmouseover="showTip(event, 'fs15', 20)" class="i">NOT_FOUND</span> <span class="s">&quot;Found no handlers&quot;</span> ]
</div></pre>

<p>You can similarly use <code>context</code> to gain access to the full <code>HttpContext</code> and connection.</p>
<p>To protect a route with HTTP Basic Authentication the combinator <code>authenticateBasic</code> is used like in the following example.</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">let</span> <span class="i">requiresAuthentication</span> _ <span class="o">=</span>
    <span onmouseout="hideTip(event, 'fs1', 21)" onmouseover="showTip(event, 'fs1', 21)" class="i">choose</span>
        [ <span onmouseout="hideTip(event, 'fs9', 22)" onmouseover="showTip(event, 'fs9', 22)" class="i">GET</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs8', 23)" onmouseover="showTip(event, 'fs8', 23)" class="i">path</span> <span class="s">&quot;/public&quot;</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs11', 24)" onmouseover="showTip(event, 'fs11', 24)" class="i">OK</span> <span class="s">&quot;Default GET&quot;</span>
          <span class="c">// Access to handlers after this one will require authentication</span>
          <span onmouseout="hideTip(event, 'fs16', 25)" onmouseover="showTip(event, 'fs16', 25)" class="i">Authentication</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs17', 26)" onmouseover="showTip(event, 'fs17', 26)" class="i">authenticateBasic</span> 
            (<span class="k">fun</span> (<span class="i">user</span>,<span class="i">pwd</span>) <span class="k">-&gt;</span> <span class="i">user</span> <span class="o">=</span> <span class="s">&quot;foo&quot;</span> <span class="o">&amp;&amp;</span> <span class="i">pwd</span> <span class="o">=</span> <span class="s">&quot;bar&quot;</span>) 
            (<span onmouseout="hideTip(event, 'fs1', 27)" onmouseover="showTip(event, 'fs1', 27)" class="i">choose</span> [
                <span onmouseout="hideTip(event, 'fs9', 28)" onmouseover="showTip(event, 'fs9', 28)" class="i">GET</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs8', 29)" onmouseover="showTip(event, 'fs8', 29)" class="i">path</span> <span class="s">&quot;/whereami&quot;</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs11', 30)" onmouseover="showTip(event, 'fs11', 30)" class="i">OK</span> (<span onmouseout="hideTip(event, 'fs7', 31)" onmouseover="showTip(event, 'fs7', 31)" class="i">sprintf</span> <span class="s">&quot;Hello authenticated person &quot;</span>)
                <span onmouseout="hideTip(event, 'fs9', 32)" onmouseover="showTip(event, 'fs9', 32)" class="i">GET</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs8', 33)" onmouseover="showTip(event, 'fs8', 33)" class="i">path</span> <span class="s">&quot;/&quot;</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs18', 34)" onmouseover="showTip(event, 'fs18', 34)" class="i">dirHome</span>
                <span onmouseout="hideTip(event, 'fs9', 35)" onmouseover="showTip(event, 'fs9', 35)" class="i">GET</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs19', 36)" onmouseover="showTip(event, 'fs19', 36)" class="i">browseHome</span> <span class="c">// Serves file if exists </span>
            ])]
</div></pre>

<p>Your web parts are "values" in the sense that they evaluate
once, e.g. when constructing <code>choose [ OK "hi" ]</code>, <code>OK "hi"</code> is evaluated once,
not every request. You need to wrap your web part in a closure if you want to
re-evaluated every request, with <code>Suave.Http.warbler</code>, <code>Suave.Types.context</code> or
<code>Suave.Types.request</code>.</p>
<p><code>warbler : (f : 'a -&gt; 'a -&gt; 'b) -&gt; 'a -&gt; 'b</code> - a piece of the applicatives
puzzle, which allows you to act on the <code>'a</code> argument and return a function that
'is the same' as after your acting on it. Using this is very useful for control
flow, because you can then inspect <code>HttpContext</code> and choose what applicative
function to return.</p>
<p><code>context</code>: basically the same as warbler.</p>
<p><code>request</code>: basically the same as context, but only looks at the request - allows
you to cut down on the pattern matching of HttpContext a bit: but you have to
return an applicative that is a WebPart (i.e. something that isn't from
HttpRequest to something else, but from HttpContext to async http context
option).</p>


<div class="tip" id="fs1">val choose : options:WebPart&lt;&#39;a&gt; list -&gt; WebPart&lt;&#39;a&gt;<br /><br />Full name: Suave.WebPart.choose</div>
<div class="tip" id="fs2">Multiple items<br />module WebPart<br /><br />from Suave<br /><br />--------------------<br />type WebPart = WebPart&lt;HttpContext&gt;<br /><br />Full name: Suave.Http.WebPart<br /><br />--------------------<br />type WebPart&lt;&#39;a&gt; = &#39;a -&gt; Async&lt;&#39;a option&gt;<br /><br />Full name: Suave.WebPart.WebPart&lt;_&gt;</div>
<div class="tip" id="fs3">type &#39;T list = List&lt;&#39;T&gt;<br /><br />Full name: Microsoft.FSharp.Collections.list&lt;_&gt;</div>
<div class="tip" id="fs4">val defaultArg : arg:&#39;T option -&gt; defaultValue:&#39;T -&gt; &#39;T<br /><br />Full name: Microsoft.FSharp.Core.Operators.defaultArg</div>
<div class="tip" id="fs5">Multiple items<br />module Option<br /><br />from YoLo<br /><br />--------------------<br />module Option<br /><br />from Microsoft.FSharp.Core</div>
<div class="tip" id="fs6">val ofChoice : _arg1:Choice&lt;&#39;a,&#39;b&gt; -&gt; &#39;a option<br /><br />Full name: YoLo.Option.ofChoice</div>
<div class="tip" id="fs7">val sprintf : format:Printf.StringFormat&lt;&#39;T&gt; -&gt; &#39;T<br /><br />Full name: Microsoft.FSharp.Core.ExtraTopLevelOperators.sprintf</div>
<div class="tip" id="fs8">val path : pathAfterDomain:string -&gt; WebPart<br /><br />Full name: Suave.Filters.path</div>
<div class="tip" id="fs9">val GET : WebPart<br /><br />Full name: Suave.Filters.GET</div>
<div class="tip" id="fs10">val request : apply:(HttpRequest -&gt; HttpContext -&gt; &#39;a) -&gt; context:HttpContext -&gt; &#39;a<br /><br />Full name: Suave.Http.request</div>
<div class="tip" id="fs11">val OK : body:string -&gt; WebPart<br /><br />Full name: Suave.Successful.OK</div>
<div class="tip" id="fs12">val query : Linq.QueryBuilder<br /><br />Full name: Microsoft.FSharp.Core.ExtraTopLevelOperators.query</div>
<div class="tip" id="fs13">val POST : WebPart<br /><br />Full name: Suave.Filters.POST</div>
<div class="tip" id="fs14">module RequestErrors<br /><br />from Suave</div>
<div class="tip" id="fs15">val NOT_FOUND : body:string -&gt; WebPart<br /><br />Full name: Suave.RequestErrors.NOT_FOUND</div>
<div class="tip" id="fs16">module Authentication<br /><br />from Suave</div>
<div class="tip" id="fs17">val authenticateBasic : f:(string * string -&gt; bool) -&gt; protectedPart:WebPart -&gt; WebPart<br /><br />Full name: Suave.Authentication.authenticateBasic</div>
<div class="tip" id="fs18">val dirHome : WebPart<br /><br />Full name: Suave.Files.dirHome</div>
<div class="tip" id="fs19">val browseHome : WebPart<br /><br />Full name: Suave.Files.browseHome</div>
