<h1>Realtime Messages With WebSockets</h1>
<p>It's easy to set up WebSockets with Suave.</p>
<p>First, define a function that takes <code>WebSocket</code> and <code>HttpContext</code> typed parameters, and returns a socket computation expression:</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">open</span> <span onmouseout="hideTip(event, 'fs1', 1)" onmouseover="showTip(event, 'fs1', 1)" class="i">Suave</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs2', 2)" onmouseover="showTip(event, 'fs2', 2)" class="i">Sockets</span>
<span class="k">open</span> <span onmouseout="hideTip(event, 'fs1', 3)" onmouseover="showTip(event, 'fs1', 3)" class="i">Suave</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs2', 4)" onmouseover="showTip(event, 'fs2', 4)" class="i">Sockets</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs3', 5)" onmouseover="showTip(event, 'fs3', 5)" class="i">Control</span>
<span class="k">open</span> <span onmouseout="hideTip(event, 'fs1', 6)" onmouseover="showTip(event, 'fs1', 6)" class="i">Suave</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs4', 7)" onmouseover="showTip(event, 'fs4', 7)" class="i">WebSocket</span>

<span class="k">let</span> <span onmouseout="hideTip(event, 'fs5', 8)" onmouseover="showTip(event, 'fs5', 8)" class="f">ws</span> (<span onmouseout="hideTip(event, 'fs6', 9)" onmouseover="showTip(event, 'fs6', 9)" class="i">webSocket</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs7', 10)" onmouseover="showTip(event, 'fs7', 10)" class="t">WebSocket</span>) (<span onmouseout="hideTip(event, 'fs8', 11)" onmouseover="showTip(event, 'fs8', 11)" class="i">context</span><span class="o">:</span> <span onmouseout="hideTip(event, 'fs9', 12)" onmouseover="showTip(event, 'fs9', 12)" class="t">HttpContext</span>) <span class="o">=</span>
    <span onmouseout="hideTip(event, 'fs10', 13)" onmouseover="showTip(event, 'fs10', 13)" class="i">socket</span> {
      <span class="o">..</span><span class="o">.</span>
    }
</div></pre>

<p>Next, use the <code>read</code> and <code>send</code> function to receive and send messages to the clients:</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span onmouseout="hideTip(event, 'fs10', 14)" onmouseover="showTip(event, 'fs10', 14)" class="i">socket</span> {
    <span class="k">let</span> <span class="k">mutable</span> <span onmouseout="hideTip(event, 'fs11', 15)" onmouseover="showTip(event, 'fs11', 15)" class="v">loop</span> <span class="o">=</span> <span class="k">true</span>

    <span class="k">while</span> <span onmouseout="hideTip(event, 'fs11', 16)" onmouseover="showTip(event, 'fs11', 16)" class="v">loop</span> <span class="k">do</span>
        <span class="k">let!</span> <span onmouseout="hideTip(event, 'fs12', 17)" onmouseover="showTip(event, 'fs12', 17)" class="i">msg</span> <span class="o">=</span> <span class="i">webSocket</span><span class="o">.</span><span class="i">read</span>()

        <span class="k">match</span> <span onmouseout="hideTip(event, 'fs12', 18)" onmouseover="showTip(event, 'fs12', 18)" class="i">msg</span> <span class="k">with</span>
        | (<span onmouseout="hideTip(event, 'fs13', 19)" onmouseover="showTip(event, 'fs13', 19)" class="p">Text</span>, <span onmouseout="hideTip(event, 'fs14', 20)" onmouseover="showTip(event, 'fs14', 20)" class="i">data</span>, <span class="k">true</span>) <span class="k">-&gt;</span>
            <span class="k">let</span> <span onmouseout="hideTip(event, 'fs15', 21)" onmouseover="showTip(event, 'fs15', 21)" class="i">str</span> <span class="o">=</span> <span onmouseout="hideTip(event, 'fs16', 22)" onmouseover="showTip(event, 'fs16', 22)" class="t">UTF8</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs17', 23)" onmouseover="showTip(event, 'fs17', 23)" class="f">toString</span> <span onmouseout="hideTip(event, 'fs14', 24)" onmouseover="showTip(event, 'fs14', 24)" class="i">data</span>
            <span class="k">let</span> <span onmouseout="hideTip(event, 'fs18', 25)" onmouseover="showTip(event, 'fs18', 25)" class="i">response</span> <span class="o">=</span> <span onmouseout="hideTip(event, 'fs19', 26)" onmouseover="showTip(event, 'fs19', 26)" class="f">sprintf</span> <span class="s">&quot;response to </span><span class="pf">%s</span><span class="s">&quot;</span> <span onmouseout="hideTip(event, 'fs15', 27)" onmouseover="showTip(event, 'fs15', 27)" class="i">str</span>
            <span class="k">let</span> <span onmouseout="hideTip(event, 'fs20', 28)" onmouseover="showTip(event, 'fs20', 28)" class="i">byteResponse</span> <span class="o">=</span>
                <span onmouseout="hideTip(event, 'fs18', 29)" onmouseover="showTip(event, 'fs18', 29)" class="i">response</span>
                <span class="o">|&gt;</span> <span onmouseout="hideTip(event, 'fs21', 30)" onmouseover="showTip(event, 'fs21', 30)" class="i">System</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs22', 31)" onmouseover="showTip(event, 'fs22', 31)" class="i">Text</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs23', 32)" onmouseover="showTip(event, 'fs23', 32)" class="t">Encoding</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs24', 33)" onmouseover="showTip(event, 'fs24', 33)" class="i">ASCII</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs25', 34)" onmouseover="showTip(event, 'fs25', 34)" class="f">GetBytes</span>
                <span class="o">|&gt;</span> <span onmouseout="hideTip(event, 'fs26', 35)" onmouseover="showTip(event, 'fs26', 35)" class="t">ByteSegment</span>
            <span class="k">do!</span> <span class="i">webSocket</span><span class="o">.</span><span class="i">send</span> <span onmouseout="hideTip(event, 'fs13', 36)" onmouseover="showTip(event, 'fs13', 36)" class="i">Text</span> <span onmouseout="hideTip(event, 'fs20', 37)" onmouseover="showTip(event, 'fs20', 37)" class="i">byteResponse</span> <span class="k">true</span>

        | (<span onmouseout="hideTip(event, 'fs27', 38)" onmouseover="showTip(event, 'fs27', 38)" class="p">Close</span>, _, _) <span class="k">-&gt;</span>
            <span class="k">let</span> <span onmouseout="hideTip(event, 'fs28', 39)" onmouseover="showTip(event, 'fs28', 39)" class="i">emptyResponse</span> <span class="o">=</span> [||] <span class="o">|&gt;</span> <span onmouseout="hideTip(event, 'fs26', 40)" onmouseover="showTip(event, 'fs26', 40)" class="t">ByteSegment</span>
            <span class="k">do!</span> <span class="i">webSocket</span><span class="o">.</span><span class="i">send</span> <span onmouseout="hideTip(event, 'fs27', 41)" onmouseover="showTip(event, 'fs27', 41)" class="i">Close</span> <span onmouseout="hideTip(event, 'fs28', 42)" onmouseover="showTip(event, 'fs28', 42)" class="i">emptyResponse</span> <span class="k">true</span>
            <span onmouseout="hideTip(event, 'fs11', 43)" onmouseover="showTip(event, 'fs11', 43)" class="v">loop</span> <span class="o">&lt;-</span> <span class="k">false</span>

        | _ <span class="k">-&gt;</span> ()
  }
</div></pre>

<p>Then, use the <code>handShake</code> function to fit it in your web server:</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">let</span> <span onmouseout="hideTip(event, 'fs29', 44)" onmouseover="showTip(event, 'fs29', 44)" class="f">app</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs30', 45)" onmouseover="showTip(event, 'fs30', 45)" class="t">WebPart</span> <span class="o">=</span>
    <span onmouseout="hideTip(event, 'fs31', 46)" onmouseover="showTip(event, 'fs31', 46)" class="f">choose</span> [
      <span onmouseout="hideTip(event, 'fs32', 47)" onmouseover="showTip(event, 'fs32', 47)" class="f">path</span> <span class="s">&quot;/websocket&quot;</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs33', 48)" onmouseover="showTip(event, 'fs33', 48)" class="f">handShake</span> <span onmouseout="hideTip(event, 'fs5', 49)" onmouseover="showTip(event, 'fs5', 49)" class="f">ws</span>
      <span onmouseout="hideTip(event, 'fs34', 50)" onmouseover="showTip(event, 'fs34', 50)" class="f">GET</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs31', 51)" onmouseover="showTip(event, 'fs31', 51)" class="f">choose</span> [ <span onmouseout="hideTip(event, 'fs32', 52)" onmouseover="showTip(event, 'fs32', 52)" class="f">path</span> <span class="s">&quot;/&quot;</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs35', 53)" onmouseover="showTip(event, 'fs35', 53)" class="f">file</span> <span class="s">&quot;index.html&quot;</span>; <span onmouseout="hideTip(event, 'fs36', 54)" onmouseover="showTip(event, 'fs36', 54)" class="f">browseHome</span> ]
      <span onmouseout="hideTip(event, 'fs37', 55)" onmouseover="showTip(event, 'fs37', 55)" class="f">NOT_FOUND</span> <span class="s">&quot;Found no handlers.&quot;</span> ]
</div></pre>

<p>The complete example can be found <a href="https://github.com/SuaveIO/suave/tree/master/examples/WebSocket">here</a>.</p>
<h2>Handling connection errors</h2>
<p>By default the socket computation expression handles any errors transparently on both writing and reading from the websocket shutting down the connection.</p>
<p>You may want to add your own additional error handling logic to catch and handle any errors raised when reading and writing from a websocket. Some scenarios where this may be useful:</p>
<ul>
<li>Alerting the rest of the application that a connection is closed.</li>
<li>Unsubscribing and/or shutting down processes used by the websocket connection.</li>
<li>Custom logging of the error.</li>
</ul>
<p>Example code can be found <a href="https://github.com/SuaveIO/suave/tree/master/examples/WebSocket">here</a>.</p>


<div class="tip" id="fs1">namespace Suave</div>
<div class="tip" id="fs2">namespace Suave.Sockets</div>
<div class="tip" id="fs3">namespace Suave.Sockets.Control</div>
<div class="tip" id="fs4">module WebSocket<br /><br />from Suave</div>
<div class="tip" id="fs5">val ws : webSocket:WebSocket -&gt; context:HttpContext -&gt; &#39;a<br /><br />Full name: temp.ws</div>
<div class="tip" id="fs6">val webSocket : WebSocket</div>
<div class="tip" id="fs7">Multiple items<br />module WebSocket<br /><br />from Suave<br /><br />--------------------<br />type WebSocket =<br />&#160;&#160;new : connection:Connection -&gt; WebSocket<br />&#160;&#160;member read : unit -&gt; Async&lt;Choice&lt;(Opcode * byte [] * bool),Error&gt;&gt;<br />&#160;&#160;member readIntoByteSegment : byteSegmentForLengthFunc:(int -&gt; ByteSegment) -&gt; Async&lt;Choice&lt;(Opcode * ByteSegment * bool),Error&gt;&gt;<br />&#160;&#160;member send : opcode:Opcode -&gt; bs:ByteSegment -&gt; fin:bool -&gt; Async&lt;Choice&lt;unit,Error&gt;&gt;<br /><br />Full name: Suave.WebSocket.WebSocket<br /><br />--------------------<br />new : connection:Connection -&gt; WebSocket</div>
<div class="tip" id="fs8">val context : HttpContext</div>
<div class="tip" id="fs9">Multiple items<br />module HttpContext<br /><br />from Suave.Http<br /><br />--------------------<br />type HttpContext =<br />&#160;&#160;{request: HttpRequest;<br />&#160;&#160;&#160;runtime: HttpRuntime;<br />&#160;&#160;&#160;connection: Connection;<br />&#160;&#160;&#160;userState: Map&lt;string,obj&gt;;<br />&#160;&#160;&#160;response: HttpResult;}<br />&#160;&#160;member clientIp : trustProxy:bool -&gt; sources:string list -&gt; IPAddress<br />&#160;&#160;member clientPort : trustProxy:bool -&gt; sources:string list -&gt; Port<br />&#160;&#160;member clientProto : trustProxy:bool -&gt; sources:string list -&gt; string<br />&#160;&#160;member clientIpTrustProxy : IPAddress<br />&#160;&#160;member clientPortTrustProxy : Port<br />&#160;&#160;member clientProtoTrustProxy : string<br />&#160;&#160;member isLocal : bool<br />&#160;&#160;static member clientIp_ : Property&lt;HttpContext,IPAddress&gt;<br />&#160;&#160;static member clientPort_ : Property&lt;HttpContext,Port&gt;<br />&#160;&#160;static member clientProto_ : Property&lt;HttpContext,string&gt;<br />&#160;&#160;static member connection_ : Property&lt;HttpContext,Connection&gt;<br />&#160;&#160;static member isLocal_ : Property&lt;HttpContext,bool&gt;<br />&#160;&#160;static member request_ : Property&lt;HttpContext,HttpRequest&gt;<br />&#160;&#160;static member response_ : Property&lt;HttpContext,HttpResult&gt;<br />&#160;&#160;static member runtime_ : Property&lt;HttpContext,HttpRuntime&gt;<br />&#160;&#160;static member userState_ : Property&lt;HttpContext,Map&lt;string,obj&gt;&gt;<br /><br />Full name: Suave.Http.HttpContext</div>
<div class="tip" id="fs10">val socket : SocketMonad<br /><br />Full name: Suave.Sockets.Control.SocketMonad.socket</div>
<div class="tip" id="fs11">val mutable loop : bool</div>
<div class="tip" id="fs12">val msg : Opcode * byte [] * bool</div>
<div class="tip" id="fs13">union case Opcode.Text: Opcode</div>
<div class="tip" id="fs14">val data : byte []</div>
<div class="tip" id="fs15">val str : string</div>
<div class="tip" id="fs16">module UTF8<br /><br />from YoLo</div>
<div class="tip" id="fs17">val toString : bs:byte [] -&gt; string<br /><br />Full name: YoLo.UTF8.toString</div>
<div class="tip" id="fs18">val response : string</div>
<div class="tip" id="fs19">val sprintf : format:Printf.StringFormat&lt;&#39;T&gt; -&gt; &#39;T<br /><br />Full name: Microsoft.FSharp.Core.ExtraTopLevelOperators.sprintf</div>
<div class="tip" id="fs20">val byteResponse : System.ArraySegment&lt;byte&gt;</div>
<div class="tip" id="fs21">namespace System</div>
<div class="tip" id="fs22">namespace System.Text</div>
<div class="tip" id="fs23">type Encoding =<br />&#160;&#160;member BodyName : string<br />&#160;&#160;member Clone : unit -&gt; obj<br />&#160;&#160;member CodePage : int<br />&#160;&#160;member DecoderFallback : DecoderFallback with get, set<br />&#160;&#160;member EncoderFallback : EncoderFallback with get, set<br />&#160;&#160;member EncodingName : string<br />&#160;&#160;member Equals : value:obj -&gt; bool<br />&#160;&#160;member GetByteCount : chars:char[] -&gt; int + 3 overloads<br />&#160;&#160;member GetBytes : chars:char[] -&gt; byte[] + 5 overloads<br />&#160;&#160;member GetCharCount : bytes:byte[] -&gt; int + 2 overloads<br />&#160;&#160;...<br /><br />Full name: System.Text.Encoding</div>
<div class="tip" id="fs24">property System.Text.Encoding.ASCII: System.Text.Encoding</div>
<div class="tip" id="fs25">System.Text.Encoding.GetBytes(s: string) : byte []<br />System.Text.Encoding.GetBytes(chars: char []) : byte []<br />System.Text.Encoding.GetBytes(chars: char [], index: int, count: int) : byte []<br />System.Text.Encoding.GetBytes(chars: nativeptr&lt;char&gt;, charCount: int, bytes: nativeptr&lt;byte&gt;, byteCount: int) : int<br />System.Text.Encoding.GetBytes(s: string, charIndex: int, charCount: int, bytes: byte [], byteIndex: int) : int<br />System.Text.Encoding.GetBytes(chars: char [], charIndex: int, charCount: int, bytes: byte [], byteIndex: int) : int</div>
<div class="tip" id="fs26">type ByteSegment = System.ArraySegment&lt;byte&gt;<br /><br />Full name: Suave.Sockets.ByteSegment</div>
<div class="tip" id="fs27">union case Opcode.Close: Opcode</div>
<div class="tip" id="fs28">val emptyResponse : System.ArraySegment&lt;byte&gt;</div>
<div class="tip" id="fs29">val app : WebPart<br /><br />Full name: temp.app</div>
<div class="tip" id="fs30">Multiple items<br />module WebPart<br /><br />from Suave<br /><br />--------------------<br />type WebPart = WebPart&lt;HttpContext&gt;<br /><br />Full name: Suave.Http.WebPart<br /><br />--------------------<br />type WebPart&lt;&#39;a&gt; = &#39;a -&gt; Async&lt;&#39;a option&gt;<br /><br />Full name: Suave.WebPart.WebPart&lt;_&gt;</div>
<div class="tip" id="fs31">val choose : options:WebPart&lt;&#39;a&gt; list -&gt; WebPart&lt;&#39;a&gt;<br /><br />Full name: Suave.WebPart.choose</div>
<div class="tip" id="fs32">val path : pathAfterDomain:string -&gt; WebPart<br /><br />Full name: Suave.Filters.path</div>
<div class="tip" id="fs33">val handShake : continuation:(WebSocket -&gt; HttpContext -&gt; SocketOp&lt;unit&gt;) -&gt; ctx:HttpContext -&gt; Async&lt;HttpContext option&gt;<br /><br />Full name: Suave.WebSocket.handShake</div>
<div class="tip" id="fs34">val GET : WebPart<br /><br />Full name: Suave.Filters.GET</div>
<div class="tip" id="fs35">val file : fileName:string -&gt; WebPart<br /><br />Full name: Suave.Files.file</div>
<div class="tip" id="fs36">val browseHome : WebPart<br /><br />Full name: Suave.Files.browseHome</div>
<div class="tip" id="fs37">val NOT_FOUND : body:string -&gt; WebPart<br /><br />Full name: Suave.RequestErrors.NOT_FOUND</div>
