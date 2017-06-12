<h1>Suave + Paket = ♥</h1>
<p>Working fully self-contained getting-started example for Suave Web Server
scripting</p>
<p>Note you don't need to have <em>anything</em> installed before starting with this
script. Nothing but F# Interactive and this script.</p>
<p>This script fetches the Paket.exe component which is referenced later in the
script. Initially the #r "paket.exe" reference is shown as unresolved. Once it
has been downloaded by the user (by executing the first part of the script) the
reference shows as resolved and can be used.</p>
<p>Paket is then used to fetch a set of F# packages, which are then used later in
the script.</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="c">// Step 0. Boilerplate to get the paket.exe tool</span>

<span class="k">open</span> <span onmouseout="hideTip(event, 'fs1', 1)" onmouseover="showTip(event, 'fs1', 1)" class="i">System</span>
<span class="k">open</span> <span onmouseout="hideTip(event, 'fs1', 2)" onmouseover="showTip(event, 'fs1', 2)" class="i">System</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs2', 3)" onmouseover="showTip(event, 'fs2', 3)" class="i">IO</span>

<span onmouseout="hideTip(event, 'fs3', 4)" onmouseover="showTip(event, 'fs3', 4)" class="t">Environment</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs4', 5)" onmouseover="showTip(event, 'fs4', 5)" class="i">CurrentDirectory</span> <span class="o">&lt;-</span> <span class="k">__SOURCE_DIRECTORY__</span>

<span class="k">if</span> <span onmouseout="hideTip(event, 'fs5', 6)" onmouseover="showTip(event, 'fs5', 6)" class="f">not</span> (<span onmouseout="hideTip(event, 'fs6', 7)" onmouseover="showTip(event, 'fs6', 7)" class="t">File</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs7', 8)" onmouseover="showTip(event, 'fs7', 8)" class="f">Exists</span> <span class="s">&quot;paket.exe&quot;</span>) <span class="k">then</span>
    <span class="k">let</span> <span onmouseout="hideTip(event, 'fs8', 9)" onmouseover="showTip(event, 'fs8', 9)" class="i">url</span> <span class="o">=</span> <span class="s">&quot;https://github.com/fsprojects/Paket/releases/download/0.31.5/paket.exe&quot;</span>
    <span class="k">use</span> <span onmouseout="hideTip(event, 'fs9', 10)" onmouseover="showTip(event, 'fs9', 10)" class="i">wc</span> <span class="o">=</span> <span class="k">new</span> <span onmouseout="hideTip(event, 'fs10', 11)" onmouseover="showTip(event, 'fs10', 11)" class="i">Net</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs11', 12)" onmouseover="showTip(event, 'fs11', 12)" class="t">WebClient</span>()
    <span class="k">let</span> <span onmouseout="hideTip(event, 'fs12', 13)" onmouseover="showTip(event, 'fs12', 13)" class="i">tmp</span> <span class="o">=</span> <span onmouseout="hideTip(event, 'fs13', 14)" onmouseover="showTip(event, 'fs13', 14)" class="t">Path</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs14', 15)" onmouseover="showTip(event, 'fs14', 15)" class="f">GetTempFileName</span>()
    <span onmouseout="hideTip(event, 'fs9', 16)" onmouseover="showTip(event, 'fs9', 16)" class="i">wc</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs15', 17)" onmouseover="showTip(event, 'fs15', 17)" class="f">DownloadFile</span>(<span onmouseout="hideTip(event, 'fs8', 18)" onmouseover="showTip(event, 'fs8', 18)" class="i">url</span>, <span onmouseout="hideTip(event, 'fs12', 19)" onmouseover="showTip(event, 'fs12', 19)" class="i">tmp</span>)
    <span onmouseout="hideTip(event, 'fs6', 20)" onmouseover="showTip(event, 'fs6', 20)" class="t">File</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs16', 21)" onmouseover="showTip(event, 'fs16', 21)" class="f">Move</span>(<span onmouseout="hideTip(event, 'fs12', 22)" onmouseover="showTip(event, 'fs12', 22)" class="i">tmp</span>,<span onmouseout="hideTip(event, 'fs13', 23)" onmouseover="showTip(event, 'fs13', 23)" class="t">Path</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs17', 24)" onmouseover="showTip(event, 'fs17', 24)" class="f">GetFileName</span> <span onmouseout="hideTip(event, 'fs8', 25)" onmouseover="showTip(event, 'fs8', 25)" class="i">url</span>);;

<span class="c">// Step 1. Resolve and install the packages</span>

<span class="prep">#r</span> <span class="s">&quot;paket.exe&quot;</span>

<span class="i">Paket</span><span class="o">.</span><span class="i">Dependencies</span><span class="o">.</span><span class="i">Install</span> <span class="s">&quot;&quot;&quot;</span>
<span class="s">frameworks: net46</span>
<span class="s">source https://nuget.org/api/v2</span>
<span class="s">nuget Suave</span>
<span class="s">&quot;&quot;&quot;</span>;;

<span class="c">// Step 2. Use the packages</span>

<span class="prep">#r</span> <span class="s">&quot;packages/Suave/lib/net40/Suave.dll&quot;</span>

<span class="k">open</span> <span onmouseout="hideTip(event, 'fs18', 26)" onmouseover="showTip(event, 'fs18', 26)" class="i">Suave</span> <span class="c">// always open suave</span>

<span onmouseout="hideTip(event, 'fs19', 27)" onmouseover="showTip(event, 'fs19', 27)" class="f">startWebServer</span> <span onmouseout="hideTip(event, 'fs20', 28)" onmouseover="showTip(event, 'fs20', 28)" class="i">defaultConfig</span> (<span onmouseout="hideTip(event, 'fs21', 29)" onmouseover="showTip(event, 'fs21', 29)" class="t">Successful</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs22', 30)" onmouseover="showTip(event, 'fs22', 30)" class="f">OK</span> <span class="s">&quot;Hello World!&quot;</span>)
</div></pre>



<div class="tip" id="fs1">namespace System</div>
<div class="tip" id="fs2">namespace System.IO</div>
<div class="tip" id="fs3">type Environment =<br />&#160;&#160;static member CommandLine : string<br />&#160;&#160;static member CurrentDirectory : string with get, set<br />&#160;&#160;static member CurrentManagedThreadId : int<br />&#160;&#160;static member Exit : exitCode:int -&gt; unit<br />&#160;&#160;static member ExitCode : int with get, set<br />&#160;&#160;static member ExpandEnvironmentVariables : name:string -&gt; string<br />&#160;&#160;static member FailFast : message:string -&gt; unit + 1 overload<br />&#160;&#160;static member GetCommandLineArgs : unit -&gt; string[]<br />&#160;&#160;static member GetEnvironmentVariable : variable:string -&gt; string + 1 overload<br />&#160;&#160;static member GetEnvironmentVariables : unit -&gt; IDictionary + 1 overload<br />&#160;&#160;...<br />&#160;&#160;nested type SpecialFolder<br />&#160;&#160;nested type SpecialFolderOption<br /><br />Full name: System.Environment</div>
<div class="tip" id="fs4">property Environment.CurrentDirectory: string</div>
<div class="tip" id="fs5">val not : value:bool -&gt; bool<br /><br />Full name: Microsoft.FSharp.Core.Operators.not</div>
<div class="tip" id="fs6">type File =<br />&#160;&#160;static member AppendAllLines : path:string * contents:IEnumerable&lt;string&gt; -&gt; unit + 1 overload<br />&#160;&#160;static member AppendAllText : path:string * contents:string -&gt; unit + 1 overload<br />&#160;&#160;static member AppendText : path:string -&gt; StreamWriter<br />&#160;&#160;static member Copy : sourceFileName:string * destFileName:string -&gt; unit + 1 overload<br />&#160;&#160;static member Create : path:string -&gt; FileStream + 3 overloads<br />&#160;&#160;static member CreateText : path:string -&gt; StreamWriter<br />&#160;&#160;static member Decrypt : path:string -&gt; unit<br />&#160;&#160;static member Delete : path:string -&gt; unit<br />&#160;&#160;static member Encrypt : path:string -&gt; unit<br />&#160;&#160;static member Exists : path:string -&gt; bool<br />&#160;&#160;...<br /><br />Full name: System.IO.File</div>
<div class="tip" id="fs7">File.Exists(path: string) : bool</div>
<div class="tip" id="fs8">val url : string</div>
<div class="tip" id="fs9">val wc : Net.WebClient</div>
<div class="tip" id="fs10">namespace System.Net</div>
<div class="tip" id="fs11">Multiple items<br />type WebClient =<br />&#160;&#160;inherit Component<br />&#160;&#160;new : unit -&gt; WebClient<br />&#160;&#160;member AllowReadStreamBuffering : bool with get, set<br />&#160;&#160;member AllowWriteStreamBuffering : bool with get, set<br />&#160;&#160;member BaseAddress : string with get, set<br />&#160;&#160;member CachePolicy : RequestCachePolicy with get, set<br />&#160;&#160;member CancelAsync : unit -&gt; unit<br />&#160;&#160;member Credentials : ICredentials with get, set<br />&#160;&#160;member DownloadData : address:string -&gt; byte[] + 1 overload<br />&#160;&#160;member DownloadDataAsync : address:Uri -&gt; unit + 1 overload<br />&#160;&#160;member DownloadDataTaskAsync : address:string -&gt; Task&lt;byte[]&gt; + 1 overload<br />&#160;&#160;...<br /><br />Full name: System.Net.WebClient<br /><br />--------------------<br />Net.WebClient() : unit</div>
<div class="tip" id="fs12">val tmp : string</div>
<div class="tip" id="fs13">type Path =<br />&#160;&#160;static val InvalidPathChars : char[]<br />&#160;&#160;static val AltDirectorySeparatorChar : char<br />&#160;&#160;static val DirectorySeparatorChar : char<br />&#160;&#160;static val PathSeparator : char<br />&#160;&#160;static val VolumeSeparatorChar : char<br />&#160;&#160;static member ChangeExtension : path:string * extension:string -&gt; string<br />&#160;&#160;static member Combine : [&lt;ParamArray&gt;] paths:string[] -&gt; string + 3 overloads<br />&#160;&#160;static member GetDirectoryName : path:string -&gt; string<br />&#160;&#160;static member GetExtension : path:string -&gt; string<br />&#160;&#160;static member GetFileName : path:string -&gt; string<br />&#160;&#160;...<br /><br />Full name: System.IO.Path</div>
<div class="tip" id="fs14">Path.GetTempFileName() : string</div>
<div class="tip" id="fs15">Net.WebClient.DownloadFile(address: Uri, fileName: string) : unit<br />Net.WebClient.DownloadFile(address: string, fileName: string) : unit</div>
<div class="tip" id="fs16">File.Move(sourceFileName: string, destFileName: string) : unit</div>
<div class="tip" id="fs17">Path.GetFileName(path: string) : string</div>
<div class="tip" id="fs18">namespace Suave</div>
<div class="tip" id="fs19">val startWebServer : config:SuaveConfig -&gt; webpart:WebPart -&gt; unit<br /><br />Full name: Suave.Web.startWebServer</div>
<div class="tip" id="fs20">val defaultConfig : SuaveConfig<br /><br />Full name: Suave.Web.defaultConfig</div>
<div class="tip" id="fs21">module Successful<br /><br />from Suave</div>
<div class="tip" id="fs22">val OK : body:string -&gt; WebPart<br /><br />Full name: Suave.Successful.OK</div>
