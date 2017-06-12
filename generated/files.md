<h1>Serving static files, HTTP Compression and MIME types</h1>
<p>A typical static file serving Suave application would look somewhat like this,
placed in <code>files.fsx</code> and serving from <code>./public</code> relative to your script file.</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="c">#!/usr/bin/env fsharpi</span>
<span class="prep">#r</span> <span class="s">&quot;./packages/Suave/lib/net40/Suave.dll&quot;</span>
<span class="k">open</span> <span onmouseout="hideTip(event, 'fs1', 1)" onmouseover="showTip(event, 'fs1', 1)" class="i">System</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs2', 2)" onmouseover="showTip(event, 'fs2', 2)" class="i">IO</span>
<span class="k">open</span> <span onmouseout="hideTip(event, 'fs3', 3)" onmouseover="showTip(event, 'fs3', 3)" class="i">Suave</span>
<span class="k">open</span> <span onmouseout="hideTip(event, 'fs3', 4)" onmouseover="showTip(event, 'fs3', 4)" class="i">Suave</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs4', 5)" onmouseover="showTip(event, 'fs4', 5)" class="i">Filters</span>
<span class="k">open</span> <span onmouseout="hideTip(event, 'fs3', 6)" onmouseover="showTip(event, 'fs3', 6)" class="i">Suave</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs5', 7)" onmouseover="showTip(event, 'fs5', 7)" class="i">Operators</span>
<span class="k">let</span> <span onmouseout="hideTip(event, 'fs6', 8)" onmouseover="showTip(event, 'fs6', 8)" class="f">app</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs7', 9)" onmouseover="showTip(event, 'fs7', 9)" class="t">WebPart</span> <span class="o">=</span>
  <span onmouseout="hideTip(event, 'fs8', 10)" onmouseover="showTip(event, 'fs8', 10)" class="f">choose</span> [
    <span onmouseout="hideTip(event, 'fs9', 11)" onmouseover="showTip(event, 'fs9', 11)" class="f">GET</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs10', 12)" onmouseover="showTip(event, 'fs10', 12)" class="f">path</span> <span class="s">&quot;/&quot;</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs11', 13)" onmouseover="showTip(event, 'fs11', 13)" class="t">Files</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs12', 14)" onmouseover="showTip(event, 'fs12', 14)" class="f">file</span> <span class="s">&quot;index.html&quot;</span>
    <span onmouseout="hideTip(event, 'fs9', 15)" onmouseover="showTip(event, 'fs9', 15)" class="f">GET</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs11', 16)" onmouseover="showTip(event, 'fs11', 16)" class="t">Files</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs13', 17)" onmouseover="showTip(event, 'fs13', 17)" class="f">browseHome</span>
    <span onmouseout="hideTip(event, 'fs14', 18)" onmouseover="showTip(event, 'fs14', 18)" class="t">RequestErrors</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs15', 19)" onmouseover="showTip(event, 'fs15', 19)" class="f">NOT_FOUND</span> <span class="s">&quot;Page not found.&quot;</span> 
  ]
<span class="k">let</span> <span onmouseout="hideTip(event, 'fs16', 20)" onmouseover="showTip(event, 'fs16', 20)" class="i">config</span> <span class="o">=</span>
  { <span onmouseout="hideTip(event, 'fs17', 21)" onmouseover="showTip(event, 'fs17', 21)" class="i">defaultConfig</span> <span class="k">with</span> <span class="i">homeFolder</span> <span class="o">=</span> <span onmouseout="hideTip(event, 'fs18', 22)" onmouseover="showTip(event, 'fs18', 22)" class="p">Some</span> (<span onmouseout="hideTip(event, 'fs19', 23)" onmouseover="showTip(event, 'fs19', 23)" class="t">Path</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs20', 24)" onmouseover="showTip(event, 'fs20', 24)" class="f">GetFullPath</span> <span class="s">&quot;./public&quot;</span>) }

<span onmouseout="hideTip(event, 'fs21', 25)" onmouseover="showTip(event, 'fs21', 25)" class="f">startWebServer</span> <span onmouseout="hideTip(event, 'fs16', 26)" onmouseover="showTip(event, 'fs16', 26)" class="i">config</span> <span onmouseout="hideTip(event, 'fs6', 27)" onmouseover="showTip(event, 'fs6', 27)" class="f">app</span>
</div></pre>

<p>The main file combinators are <code>file</code>, <code>browseHome</code> and variations of these. To
learn about all of them check out the Files module
<a href="https://suave.io/Suave.html#def:module%20Suave.Files">documentation</a></p>
<p><code>file</code> will take the relative or absolute path for the file we want to serve to
the client. It will set MIME-type headers based on the file extension.</p>
<p><code>browseHome</code> will match existing files in the <code>homeFolder</code> based on the <code>Url</code>
property and will serve them via the <code>file</code> combinator; <code>homeFolder</code> is a
configuration parameter and can be set in the configuration record.</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span onmouseout="hideTip(event, 'fs21', 28)" onmouseover="showTip(event, 'fs21', 28)" class="f">startWebServer</span> { <span onmouseout="hideTip(event, 'fs17', 29)" onmouseover="showTip(event, 'fs17', 29)" class="i">defaultConfig</span> <span class="k">with</span> <span class="i">homeFolder</span> <span class="o">=</span> <span onmouseout="hideTip(event, 'fs18', 30)" onmouseover="showTip(event, 'fs18', 30)" class="p">Some</span> <span class="s">@&quot;C:\MyFiles&quot;</span> } <span onmouseout="hideTip(event, 'fs6', 31)" onmouseover="showTip(event, 'fs6', 31)" class="f">app</span>
</div></pre>

<p>Suave supports <strong>gzip</strong> and <strong>deflate</strong> http compression encodings. Http
compression is configured via the MIME types map in the server configuration
record.</p>
<p>By default Suave does not serve files with extensions not registered in
the mime types map.</p>
<p>The default mime types map <code>defaultMimeTypesMap</code> looks like this.</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">let</span> <span onmouseout="hideTip(event, 'fs22', 32)" onmouseover="showTip(event, 'fs22', 32)" class="f">defaultMimeTypesMap</span> <span class="o">=</span> <span class="k">function</span>
  | <span class="s">&quot;.css&quot;</span> <span class="k">-&gt;</span> <span class="i">createMimeType</span> <span class="s">&quot;text/css&quot;</span> <span class="k">true</span>
  | <span class="s">&quot;.gif&quot;</span> <span class="k">-&gt;</span> <span class="i">createMimeType</span> <span class="s">&quot;image/gif&quot;</span> <span class="k">false</span>
  | <span class="s">&quot;.png&quot;</span> <span class="k">-&gt;</span> <span class="i">createMimeType</span> <span class="s">&quot;image/png&quot;</span> <span class="k">false</span>
  | <span class="s">&quot;.htm&quot;</span>
  | <span class="s">&quot;.html&quot;</span> <span class="k">-&gt;</span> <span class="i">createMimeType</span> <span class="s">&quot;text/html&quot;</span> <span class="k">true</span>
  | <span class="s">&quot;.jpe&quot;</span>
  | <span class="s">&quot;.jpeg&quot;</span>
  | <span class="s">&quot;.jpg&quot;</span> <span class="k">-&gt;</span> <span class="i">createMimeType</span> <span class="s">&quot;image/jpeg&quot;</span> <span class="k">false</span>
  | <span class="s">&quot;.js&quot;</span>  <span class="k">-&gt;</span> <span class="i">createMimeType</span> <span class="s">&quot;application/x-javascript&quot;</span> <span class="k">true</span>
  <span class="c">// ... some stuff left out</span>
  | _      <span class="k">-&gt;</span> <span onmouseout="hideTip(event, 'fs23', 33)" onmouseover="showTip(event, 'fs23', 33)" class="p">None</span>
</div></pre>

<p>You can register additional MIME extensions by creating a new mime map in the following fashion.</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="c">// Adds a new mime type to the default map</span>
<span class="k">let</span> <span onmouseout="hideTip(event, 'fs24', 34)" onmouseover="showTip(event, 'fs24', 34)" class="f">mimeTypes</span> <span class="o">=</span>
  <span onmouseout="hideTip(event, 'fs22', 35)" onmouseover="showTip(event, 'fs22', 35)" class="f">defaultMimeTypesMap</span>
    <span class="o">@@</span> (<span class="k">function</span> | <span class="s">&quot;.avi&quot;</span> <span class="k">-&gt;</span> <span class="i">createMimeType</span> <span class="s">&quot;video/avi&quot;</span> <span class="k">false</span> | _ <span class="k">-&gt;</span> <span onmouseout="hideTip(event, 'fs23', 36)" onmouseover="showTip(event, 'fs23', 36)" class="p">None</span>)

<span class="k">let</span> <span onmouseout="hideTip(event, 'fs25', 37)" onmouseover="showTip(event, 'fs25', 37)" class="i">webConfig</span> <span class="o">=</span> { <span onmouseout="hideTip(event, 'fs17', 38)" onmouseover="showTip(event, 'fs17', 38)" class="i">defaultConfig</span> <span class="k">with</span> <span class="i">mimeTypesMap</span> <span class="o">=</span> <span onmouseout="hideTip(event, 'fs24', 39)" onmouseover="showTip(event, 'fs24', 39)" class="f">mimeTypes</span> }
</div></pre>



<div class="tip" id="fs1">namespace System</div>
<div class="tip" id="fs2">namespace System.IO</div>
<div class="tip" id="fs3">namespace Suave</div>
<div class="tip" id="fs4">module Filters<br /><br />from Suave</div>
<div class="tip" id="fs5">module Operators<br /><br />from Suave</div>
<div class="tip" id="fs6">val app : WebPart<br /><br />Full name: temp.app</div>
<div class="tip" id="fs7">Multiple items<br />module WebPart<br /><br />from Suave<br /><br />--------------------<br />type WebPart = WebPart&lt;HttpContext&gt;<br /><br />Full name: Suave.Http.WebPart<br /><br />--------------------<br />type WebPart&lt;&#39;a&gt; = &#39;a -&gt; Async&lt;&#39;a option&gt;<br /><br />Full name: Suave.WebPart.WebPart&lt;_&gt;</div>
<div class="tip" id="fs8">val choose : options:WebPart&lt;&#39;a&gt; list -&gt; WebPart&lt;&#39;a&gt;<br /><br />Full name: Suave.WebPart.choose</div>
<div class="tip" id="fs9">val GET : WebPart<br /><br />Full name: Suave.Filters.GET</div>
<div class="tip" id="fs10">val path : pathAfterDomain:string -&gt; WebPart<br /><br />Full name: Suave.Filters.path</div>
<div class="tip" id="fs11">module Files<br /><br />from Suave</div>
<div class="tip" id="fs12">val file : fileName:string -&gt; WebPart<br /><br />Full name: Suave.Files.file</div>
<div class="tip" id="fs13">val browseHome : WebPart<br /><br />Full name: Suave.Files.browseHome</div>
<div class="tip" id="fs14">module RequestErrors<br /><br />from Suave</div>
<div class="tip" id="fs15">val NOT_FOUND : body:string -&gt; WebPart<br /><br />Full name: Suave.RequestErrors.NOT_FOUND</div>
<div class="tip" id="fs16">val config : SuaveConfig<br /><br />Full name: temp.config</div>
<div class="tip" id="fs17">val defaultConfig : SuaveConfig<br /><br />Full name: Suave.Web.defaultConfig</div>
<div class="tip" id="fs18">union case Option.Some: Value: &#39;T -&gt; Option&lt;&#39;T&gt;</div>
<div class="tip" id="fs19">type Path =<br />&#160;&#160;static val InvalidPathChars : char[]<br />&#160;&#160;static val AltDirectorySeparatorChar : char<br />&#160;&#160;static val DirectorySeparatorChar : char<br />&#160;&#160;static val PathSeparator : char<br />&#160;&#160;static val VolumeSeparatorChar : char<br />&#160;&#160;static member ChangeExtension : path:string * extension:string -&gt; string<br />&#160;&#160;static member Combine : [&lt;ParamArray&gt;] paths:string[] -&gt; string + 3 overloads<br />&#160;&#160;static member GetDirectoryName : path:string -&gt; string<br />&#160;&#160;static member GetExtension : path:string -&gt; string<br />&#160;&#160;static member GetFileName : path:string -&gt; string<br />&#160;&#160;...<br /><br />Full name: System.IO.Path</div>
<div class="tip" id="fs20">Path.GetFullPath(path: string) : string</div>
<div class="tip" id="fs21">val startWebServer : config:SuaveConfig -&gt; webpart:WebPart -&gt; unit<br /><br />Full name: Suave.Web.startWebServer</div>
<div class="tip" id="fs22">val defaultMimeTypesMap : _arg1:string -&gt; &#39;a option<br /><br />Full name: temp.defaultMimeTypesMap</div>
<div class="tip" id="fs23">union case Option.None: Option&lt;&#39;T&gt;</div>
<div class="tip" id="fs24">val mimeTypes : (string -&gt; MimeType option)<br /><br />Full name: temp.mimeTypes</div>
<div class="tip" id="fs25">val webConfig : SuaveConfig<br /><br />Full name: temp.webConfig</div>
