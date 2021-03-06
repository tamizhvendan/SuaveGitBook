<h1>Introduction</h1>
<p>Suave is a lightweight, non-blocking web server. The non-blocking I/O model is efficient and suitable for building fast, scalable network applications. In fact, Suave is written in a <strong>completely non-blocking</strong> fashion throughout. Suave <strong>runs on Linux</strong>, OS X and Windows flawlessly.</p>
<p>Suave is inspired in the simplicity of Happstack and born out of the necessity
of embedding web server capabilities in my own applications. Still in its early
stages Suave supports HTTPS, multiple TCP/IP bindings, Basic Access
Authentication, Keep-Alive and HTTP compression.</p>
<h2>NuGet</h2>
<p>To install Suave, add the following to your
<a href="https://github.com/fsprojects/Paket">paket</a>.dependencies:</p>
<table class="pre"><tr><td class="snippet"><pre class="fssnip highlighted"><div lang="csharp">source https:<span class="c">//nuget.org/api/v2</span>
nuget Suave
</div></pre>
</td></tr></table>
<p>Or you can use the legacy NuGet command line <a href="http://docs.nuget.org/docs/start-here/using-the-package-manager-console">Package Manager
Console</a>:</p>
<table class="pre"><tr><td class="snippet"><pre class="fssnip highlighted"><div lang="csharp">PM&gt; Install-Package Suave
</div></pre>
</td></tr></table>
<h2>The simplest possible application: Hello World!</h2>
<p>The simplest Suave application is a simple HTTP server that greets all visitors
with the string <code>"Hello World!"</code></p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">open</span> <span onmouseout="hideTip(event, 'fs1', 1)" onmouseover="showTip(event, 'fs1', 1)" class="i">Suave</span>

<span onmouseout="hideTip(event, 'fs2', 2)" onmouseover="showTip(event, 'fs2', 2)" class="f">startWebServer</span> <span onmouseout="hideTip(event, 'fs3', 3)" onmouseover="showTip(event, 'fs3', 3)" class="i">defaultConfig</span> (<span onmouseout="hideTip(event, 'fs4', 4)" onmouseover="showTip(event, 'fs4', 4)" class="t">Successful</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs5', 5)" onmouseover="showTip(event, 'fs5', 5)" class="f">OK</span> <span class="s">&quot;Hello World!&quot;</span>)
</div></pre>

<p>The above statement will start a web server on default port 8083 over HTTP.
<code>startWebServer</code> takes a configuration record and the WebPart <code>(OK "Hello
World")</code> It's worth noting that with the above, your application will block on
the function call, until you cancel the <code>Async.DefaultCancellationToken</code>. If you
want to handle disposal of the async yourself, have a look at
<code>startWebServerAsync</code>.</p>
<p>Ta-daa!</p>
<p>To test the above yourself, paste that code in <code>Hello.fsx</code> and then invoke it
with <code>fsharpi Hello.fsx</code> (or <code>fsi Hello.fsx</code> on Windows). Completely new? Here
are installation instructions on <a href="http://fsharp.org/use/mac/">OS X/macOS</a>,
<a href="http://fsharp.org/use/windows/">Windows</a> and
<a href="http://fsharp.org/use/linux/">Linux</a>. If you have Visual Studio installed you
should be able to find the "F# Interactive" in your menus.</p>
<p>If you are running in an IDE, and not starting Suave via <code>Hello.fsx</code>, you'll
want to provide a way of stopping the server without having to restart the IDE;
the code below will run the server until a key is pressed in the console window,
then shuts down the server.</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">open</span> <span onmouseout="hideTip(event, 'fs6', 6)" onmouseover="showTip(event, 'fs6', 6)" class="i">System</span>
<span class="k">open</span> <span onmouseout="hideTip(event, 'fs6', 7)" onmouseover="showTip(event, 'fs6', 7)" class="i">System</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs7', 8)" onmouseover="showTip(event, 'fs7', 8)" class="i">Threading</span>
<span class="k">open</span> <span onmouseout="hideTip(event, 'fs1', 9)" onmouseover="showTip(event, 'fs1', 9)" class="i">Suave</span>

[&lt;<span onmouseout="hideTip(event, 'fs8', 10)" onmouseover="showTip(event, 'fs8', 10)" class="t">EntryPoint</span>&gt;]
<span class="k">let</span> <span onmouseout="hideTip(event, 'fs9', 11)" onmouseover="showTip(event, 'fs9', 11)" class="f">main</span> <span onmouseout="hideTip(event, 'fs10', 12)" onmouseover="showTip(event, 'fs10', 12)" class="i">argv</span> <span class="o">=</span> 
  <span class="k">let</span> <span onmouseout="hideTip(event, 'fs11', 13)" onmouseover="showTip(event, 'fs11', 13)" class="i">cts</span> <span class="o">=</span> <span class="k">new</span> <span onmouseout="hideTip(event, 'fs12', 14)" onmouseover="showTip(event, 'fs12', 14)" class="t">CancellationTokenSource</span>()
  <span class="k">let</span> <span onmouseout="hideTip(event, 'fs13', 15)" onmouseover="showTip(event, 'fs13', 15)" class="i">conf</span> <span class="o">=</span> { <span onmouseout="hideTip(event, 'fs3', 16)" onmouseover="showTip(event, 'fs3', 16)" class="i">defaultConfig</span> <span class="k">with</span> <span class="i">cancellationToken</span> <span class="o">=</span> <span onmouseout="hideTip(event, 'fs11', 17)" onmouseover="showTip(event, 'fs11', 17)" class="i">cts</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs14', 18)" onmouseover="showTip(event, 'fs14', 18)" class="i">Token</span> }
  <span class="k">let</span> <span onmouseout="hideTip(event, 'fs15', 19)" onmouseover="showTip(event, 'fs15', 19)" class="i">listening</span>, <span onmouseout="hideTip(event, 'fs16', 20)" onmouseover="showTip(event, 'fs16', 20)" class="i">server</span> <span class="o">=</span> <span onmouseout="hideTip(event, 'fs17', 21)" onmouseover="showTip(event, 'fs17', 21)" class="f">startWebServerAsync</span> <span onmouseout="hideTip(event, 'fs13', 22)" onmouseover="showTip(event, 'fs13', 22)" class="i">conf</span> (<span onmouseout="hideTip(event, 'fs4', 23)" onmouseover="showTip(event, 'fs4', 23)" class="t">Successful</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs5', 24)" onmouseover="showTip(event, 'fs5', 24)" class="f">OK</span> <span class="s">&quot;Hello World&quot;</span>)

  <span onmouseout="hideTip(event, 'fs18', 25)" onmouseover="showTip(event, 'fs18', 25)" class="t">Async</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs19', 26)" onmouseover="showTip(event, 'fs19', 26)" class="f">Start</span>(<span onmouseout="hideTip(event, 'fs16', 27)" onmouseover="showTip(event, 'fs16', 27)" class="i">server</span>, <span onmouseout="hideTip(event, 'fs11', 28)" onmouseover="showTip(event, 'fs11', 28)" class="i">cts</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs14', 29)" onmouseover="showTip(event, 'fs14', 29)" class="i">Token</span>)
  <span onmouseout="hideTip(event, 'fs20', 30)" onmouseover="showTip(event, 'fs20', 30)" class="f">printfn</span> <span class="s">&quot;Make requests now&quot;</span>
  <span onmouseout="hideTip(event, 'fs21', 31)" onmouseover="showTip(event, 'fs21', 31)" class="t">Console</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs22', 32)" onmouseover="showTip(event, 'fs22', 32)" class="f">ReadKey</span> <span class="k">true</span> <span class="o">|&gt;</span> <span onmouseout="hideTip(event, 'fs23', 33)" onmouseover="showTip(event, 'fs23', 33)" class="f">ignore</span>    
  <span onmouseout="hideTip(event, 'fs11', 34)" onmouseover="showTip(event, 'fs11', 34)" class="i">cts</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs24', 35)" onmouseover="showTip(event, 'fs24', 35)" class="f">Cancel</span>()

  <span class="n">0</span> <span class="c">// return an integer exit code</span>
</div></pre>

<p>In suave, we have opted to write a lot of documentation inside the code; so just
hover the function in your IDE or use an assembly browser to bring out the XML
docs. You can also browse <a href="https://suave.io/Suave.html">our API reference</a>.</p>


<div class="tip" id="fs1">namespace Suave</div>
<div class="tip" id="fs2">val startWebServer : config:SuaveConfig -&gt; webpart:WebPart -&gt; unit<br /><br />Full name: Suave.Web.startWebServer</div>
<div class="tip" id="fs3">val defaultConfig : SuaveConfig<br /><br />Full name: Suave.Web.defaultConfig</div>
<div class="tip" id="fs4">module Successful<br /><br />from Suave</div>
<div class="tip" id="fs5">val OK : body:string -&gt; WebPart<br /><br />Full name: Suave.Successful.OK</div>
<div class="tip" id="fs6">namespace System</div>
<div class="tip" id="fs7">namespace System.Threading</div>
<div class="tip" id="fs8">Multiple items<br />type EntryPointAttribute =<br />&#160;&#160;inherit Attribute<br />&#160;&#160;new : unit -&gt; EntryPointAttribute<br /><br />Full name: Microsoft.FSharp.Core.EntryPointAttribute<br /><br />--------------------<br />new : unit -&gt; EntryPointAttribute</div>
<div class="tip" id="fs9">val main : argv:string [] -&gt; int<br /><br />Full name: temp.main</div>
<div class="tip" id="fs10">val argv : string []</div>
<div class="tip" id="fs11">val cts : CancellationTokenSource</div>
<div class="tip" id="fs12">Multiple items<br />type CancellationTokenSource =<br />&#160;&#160;new : unit -&gt; CancellationTokenSource + 2 overloads<br />&#160;&#160;member Cancel : unit -&gt; unit + 1 overload<br />&#160;&#160;member CancelAfter : delay:TimeSpan -&gt; unit + 1 overload<br />&#160;&#160;member Dispose : unit -&gt; unit<br />&#160;&#160;member IsCancellationRequested : bool<br />&#160;&#160;member Token : CancellationToken<br />&#160;&#160;static member CreateLinkedTokenSource : [&lt;ParamArray&gt;] tokens:CancellationToken[] -&gt; CancellationTokenSource + 1 overload<br /><br />Full name: System.Threading.CancellationTokenSource<br /><br />--------------------<br />CancellationTokenSource() : unit<br />CancellationTokenSource(delay: TimeSpan) : unit<br />CancellationTokenSource(millisecondsDelay: int) : unit</div>
<div class="tip" id="fs13">val conf : SuaveConfig</div>
<div class="tip" id="fs14">property CancellationTokenSource.Token: CancellationToken</div>
<div class="tip" id="fs15">val listening : Async&lt;Tcp.StartedData option []&gt;</div>
<div class="tip" id="fs16">val server : Async&lt;unit&gt;</div>
<div class="tip" id="fs17">val startWebServerAsync : config:SuaveConfig -&gt; webpart:WebPart -&gt; Async&lt;Tcp.StartedData option []&gt; * Async&lt;unit&gt;<br /><br />Full name: Suave.Web.startWebServerAsync</div>
<div class="tip" id="fs18">Multiple items<br />module Async<br /><br />from YoLo<br /><br />--------------------<br />type Async<br />static member AsBeginEnd : computation:(&#39;Arg -&gt; Async&lt;&#39;T&gt;) -&gt; (&#39;Arg * AsyncCallback * obj -&gt; IAsyncResult) * (IAsyncResult -&gt; &#39;T) * (IAsyncResult -&gt; unit)<br />static member AwaitEvent : event:IEvent&lt;&#39;Del,&#39;T&gt; * ?cancelAction:(unit -&gt; unit) -&gt; Async&lt;&#39;T&gt; (requires delegate and &#39;Del :&gt; Delegate)<br />static member AwaitIAsyncResult : iar:IAsyncResult * ?millisecondsTimeout:int -&gt; Async&lt;bool&gt;<br />static member AwaitTask : task:Task -&gt; Async&lt;unit&gt;<br />static member AwaitTask : task:Task&lt;&#39;T&gt; -&gt; Async&lt;&#39;T&gt;<br />static member AwaitWaitHandle : waitHandle:WaitHandle * ?millisecondsTimeout:int -&gt; Async&lt;bool&gt;<br />static member CancelDefaultToken : unit -&gt; unit<br />static member Catch : computation:Async&lt;&#39;T&gt; -&gt; Async&lt;Choice&lt;&#39;T,exn&gt;&gt;<br />static member Choice : computations:seq&lt;Async&lt;&#39;T option&gt;&gt; -&gt; Async&lt;&#39;T option&gt;<br />static member FromBeginEnd : beginAction:(AsyncCallback * obj -&gt; IAsyncResult) * endAction:(IAsyncResult -&gt; &#39;T) * ?cancelAction:(unit -&gt; unit) -&gt; Async&lt;&#39;T&gt;<br />static member FromBeginEnd : arg:&#39;Arg1 * beginAction:(&#39;Arg1 * AsyncCallback * obj -&gt; IAsyncResult) * endAction:(IAsyncResult -&gt; &#39;T) * ?cancelAction:(unit -&gt; unit) -&gt; Async&lt;&#39;T&gt;<br />static member FromBeginEnd : arg1:&#39;Arg1 * arg2:&#39;Arg2 * beginAction:(&#39;Arg1 * &#39;Arg2 * AsyncCallback * obj -&gt; IAsyncResult) * endAction:(IAsyncResult -&gt; &#39;T) * ?cancelAction:(unit -&gt; unit) -&gt; Async&lt;&#39;T&gt;<br />static member FromBeginEnd : arg1:&#39;Arg1 * arg2:&#39;Arg2 * arg3:&#39;Arg3 * beginAction:(&#39;Arg1 * &#39;Arg2 * &#39;Arg3 * AsyncCallback * obj -&gt; IAsyncResult) * endAction:(IAsyncResult -&gt; &#39;T) * ?cancelAction:(unit -&gt; unit) -&gt; Async&lt;&#39;T&gt;<br />static member FromContinuations : callback:((&#39;T -&gt; unit) * (exn -&gt; unit) * (OperationCanceledException -&gt; unit) -&gt; unit) -&gt; Async&lt;&#39;T&gt;<br />static member Ignore : computation:Async&lt;&#39;T&gt; -&gt; Async&lt;unit&gt;<br />static member OnCancel : interruption:(unit -&gt; unit) -&gt; Async&lt;IDisposable&gt;<br />static member Parallel : computations:seq&lt;Async&lt;&#39;T&gt;&gt; -&gt; Async&lt;&#39;T []&gt;<br />static member RunSynchronously : computation:Async&lt;&#39;T&gt; * ?timeout:int * ?cancellationToken:CancellationToken -&gt; &#39;T<br />static member Sleep : millisecondsDueTime:int -&gt; Async&lt;unit&gt;<br />static member Start : computation:Async&lt;unit&gt; * ?cancellationToken:CancellationToken -&gt; unit<br />static member StartAsTask : computation:Async&lt;&#39;T&gt; * ?taskCreationOptions:TaskCreationOptions * ?cancellationToken:CancellationToken -&gt; Task&lt;&#39;T&gt;<br />static member StartChild : computation:Async&lt;&#39;T&gt; * ?millisecondsTimeout:int -&gt; Async&lt;Async&lt;&#39;T&gt;&gt;<br />static member StartChildAsTask : computation:Async&lt;&#39;T&gt; * ?taskCreationOptions:TaskCreationOptions -&gt; Async&lt;Task&lt;&#39;T&gt;&gt;<br />static member StartImmediate : computation:Async&lt;unit&gt; * ?cancellationToken:CancellationToken -&gt; unit<br />static member StartWithContinuations : computation:Async&lt;&#39;T&gt; * continuation:(&#39;T -&gt; unit) * exceptionContinuation:(exn -&gt; unit) * cancellationContinuation:(OperationCanceledException -&gt; unit) * ?cancellationToken:CancellationToken -&gt; unit<br />static member SwitchToContext : syncContext:SynchronizationContext -&gt; Async&lt;unit&gt;<br />static member SwitchToNewThread : unit -&gt; Async&lt;unit&gt;<br />static member SwitchToThreadPool : unit -&gt; Async&lt;unit&gt;<br />static member TryCancelled : computation:Async&lt;&#39;T&gt; * compensation:(OperationCanceledException -&gt; unit) -&gt; Async&lt;&#39;T&gt;<br />static member CancellationToken : Async&lt;CancellationToken&gt;<br />static member DefaultCancellationToken : CancellationToken<br /><br />Full name: Microsoft.FSharp.Control.Async<br /><br />--------------------<br />type Async&lt;&#39;T&gt;<br /><br />Full name: Microsoft.FSharp.Control.Async&lt;_&gt;</div>
<div class="tip" id="fs19">static member Async.Start : computation:Async&lt;unit&gt; * ?cancellationToken:CancellationToken -&gt; unit</div>
<div class="tip" id="fs20">val printfn : format:Printf.TextWriterFormat&lt;&#39;T&gt; -&gt; &#39;T<br /><br />Full name: Microsoft.FSharp.Core.ExtraTopLevelOperators.printfn</div>
<div class="tip" id="fs21">type Console =<br />&#160;&#160;static member BackgroundColor : ConsoleColor with get, set<br />&#160;&#160;static member Beep : unit -&gt; unit + 1 overload<br />&#160;&#160;static member BufferHeight : int with get, set<br />&#160;&#160;static member BufferWidth : int with get, set<br />&#160;&#160;static member CapsLock : bool<br />&#160;&#160;static member Clear : unit -&gt; unit<br />&#160;&#160;static member CursorLeft : int with get, set<br />&#160;&#160;static member CursorSize : int with get, set<br />&#160;&#160;static member CursorTop : int with get, set<br />&#160;&#160;static member CursorVisible : bool with get, set<br />&#160;&#160;...<br /><br />Full name: System.Console</div>
<div class="tip" id="fs22">Console.ReadKey() : ConsoleKeyInfo<br />Console.ReadKey(intercept: bool) : ConsoleKeyInfo</div>
<div class="tip" id="fs23">val ignore : value:&#39;T -&gt; unit<br /><br />Full name: Microsoft.FSharp.Core.Operators.ignore</div>
<div class="tip" id="fs24">CancellationTokenSource.Cancel() : unit<br />CancellationTokenSource.Cancel(throwOnFirstException: bool) : unit</div>
