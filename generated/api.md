<h1>API</h1>
<h2>HttpContext</h2>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">type</span> <span onmouseout="hideTip(event, 'fs1', 1)" onmouseover="showTip(event, 'fs1', 1)" class="t">ErrorHandler</span> <span class="o">=</span> <span class="i">Exception</span> <span class="k">-&gt;</span> <span onmouseout="hideTip(event, 'fs2', 2)" onmouseover="showTip(event, 'fs2', 2)" class="i">String</span> <span class="k">-&gt;</span> <span onmouseout="hideTip(event, 'fs3', 3)" onmouseover="showTip(event, 'fs3', 3)" class="t">HttpContext</span> <span class="k">-&gt;</span> <span onmouseout="hideTip(event, 'fs3', 4)" onmouseover="showTip(event, 'fs3', 4)" class="t">HttpContext</span>

<span class="k">and</span> <span onmouseout="hideTip(event, 'fs4', 5)" onmouseover="showTip(event, 'fs4', 5)" class="t">HttpRuntime</span> <span class="o">=</span>
  { <span onmouseout="hideTip(event, 'fs5', 6)" onmouseover="showTip(event, 'fs5', 6)" class="i">protocol</span>          <span class="o">:</span> <span onmouseout="hideTip(event, 'fs6', 7)" onmouseover="showTip(event, 'fs6', 7)" class="t">Protocol</span>
    <span onmouseout="hideTip(event, 'fs7', 8)" onmouseover="showTip(event, 'fs7', 8)" class="i">errorHandler</span>      <span class="o">:</span> <span onmouseout="hideTip(event, 'fs1', 9)" onmouseover="showTip(event, 'fs1', 9)" class="t">ErrorHandler</span>
    <span onmouseout="hideTip(event, 'fs8', 10)" onmouseover="showTip(event, 'fs8', 10)" class="i">mimeTypesMap</span>      <span class="o">:</span> <span onmouseout="hideTip(event, 'fs9', 11)" onmouseover="showTip(event, 'fs9', 11)" class="t">MimeTypesMap</span>
    <span onmouseout="hideTip(event, 'fs10', 12)" onmouseover="showTip(event, 'fs10', 12)" class="i">homeDirectory</span>     <span class="o">:</span> <span onmouseout="hideTip(event, 'fs11', 13)" onmouseover="showTip(event, 'fs11', 13)" class="t">string</span>
    <span onmouseout="hideTip(event, 'fs12', 14)" onmouseover="showTip(event, 'fs12', 14)" class="i">compressionFolder</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs11', 15)" onmouseover="showTip(event, 'fs11', 15)" class="t">string</span>
    <span onmouseout="hideTip(event, 'fs13', 16)" onmouseover="showTip(event, 'fs13', 16)" class="i">logger</span>            <span class="o">:</span> <span onmouseout="hideTip(event, 'fs14', 17)" onmouseover="showTip(event, 'fs14', 17)" class="i">Log</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs15', 18)" onmouseover="showTip(event, 'fs15', 18)" class="i">Logger</span>
    <span onmouseout="hideTip(event, 'fs16', 19)" onmouseover="showTip(event, 'fs16', 19)" class="i">sessionProvider</span>   <span class="o">:</span> <span onmouseout="hideTip(event, 'fs17', 20)" onmouseover="showTip(event, 'fs17', 20)" class="t">ISessionProvider</span> }

<span class="k">and</span> <span onmouseout="hideTip(event, 'fs3', 21)" onmouseover="showTip(event, 'fs3', 21)" class="t">HttpContext</span> <span class="o">=</span>
  { <span onmouseout="hideTip(event, 'fs18', 22)" onmouseover="showTip(event, 'fs18', 22)" class="i">request</span>   <span class="o">:</span> <span onmouseout="hideTip(event, 'fs19', 23)" onmouseover="showTip(event, 'fs19', 23)" class="t">HttpRequest</span>
    <span onmouseout="hideTip(event, 'fs20', 24)" onmouseover="showTip(event, 'fs20', 24)" class="i">runtime</span>   <span class="o">:</span> <span onmouseout="hideTip(event, 'fs4', 25)" onmouseover="showTip(event, 'fs4', 25)" class="t">HttpRuntime</span>
    <span onmouseout="hideTip(event, 'fs21', 26)" onmouseover="showTip(event, 'fs21', 26)" class="i">userState</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs22', 27)" onmouseover="showTip(event, 'fs22', 27)" class="t">Map</span><span class="o">&lt;</span><span onmouseout="hideTip(event, 'fs11', 28)" onmouseover="showTip(event, 'fs11', 28)" class="t">string</span>, <span onmouseout="hideTip(event, 'fs23', 29)" onmouseover="showTip(event, 'fs23', 29)" class="t">obj</span><span class="o">&gt;</span>
    <span onmouseout="hideTip(event, 'fs24', 30)" onmouseover="showTip(event, 'fs24', 30)" class="i">response</span>  <span class="o">:</span> <span onmouseout="hideTip(event, 'fs25', 31)" onmouseover="showTip(event, 'fs25', 31)" class="t">HttpResult</span> }

<span class="k">and</span> <span onmouseout="hideTip(event, 'fs17', 32)" onmouseover="showTip(event, 'fs17', 32)" class="t">ISessionProvider</span> <span class="o">=</span>
  <span class="k">abstract</span> <span class="k">member</span> <span onmouseout="hideTip(event, 'fs26', 33)" onmouseover="showTip(event, 'fs26', 33)" class="f">Generate</span> <span class="o">:</span> <span class="i">TimeSpan</span> <span class="o">*</span> <span onmouseout="hideTip(event, 'fs3', 34)" onmouseover="showTip(event, 'fs3', 34)" class="t">HttpContext</span> <span class="k">-&gt;</span> <span onmouseout="hideTip(event, 'fs11', 35)" onmouseover="showTip(event, 'fs11', 35)" class="t">string</span>
  <span class="k">abstract</span> <span class="k">member</span> <span onmouseout="hideTip(event, 'fs27', 36)" onmouseover="showTip(event, 'fs27', 36)" class="f">Validate</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs11', 37)" onmouseover="showTip(event, 'fs11', 37)" class="t">string</span> <span class="o">*</span> <span onmouseout="hideTip(event, 'fs3', 38)" onmouseover="showTip(event, 'fs3', 38)" class="t">HttpContext</span> <span class="k">-&gt;</span> <span onmouseout="hideTip(event, 'fs28', 39)" onmouseover="showTip(event, 'fs28', 39)" class="t">bool</span>
  <span class="k">abstract</span> <span class="k">member</span> <span onmouseout="hideTip(event, 'fs29', 40)" onmouseover="showTip(event, 'fs29', 40)" class="f">Session</span><span class="o">&lt;</span><span class="o">&#39;</span><span class="i">a</span><span class="o">&gt;</span>  <span class="o">:</span> <span onmouseout="hideTip(event, 'fs11', 41)" onmouseover="showTip(event, 'fs11', 41)" class="t">string</span> <span class="k">-&gt;</span> <span class="i">SessionStore</span><span class="o">&lt;</span><span class="o">&#39;</span><span class="i">a</span><span class="o">&gt;</span>
</div></pre>

<h2>Default-supported HTTP Verbs</h2>
<p>See <a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec9.html">RFC 2616</a>.</p>
<p>These applicatives match on HTTP verbs.</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">let</span> <span onmouseout="hideTip(event, 'fs30', 42)" onmouseover="showTip(event, 'fs30', 42)" class="f">GET</span>     (<span onmouseout="hideTip(event, 'fs31', 43)" onmouseover="showTip(event, 'fs31', 43)" class="i">x</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs19', 44)" onmouseover="showTip(event, 'fs19', 44)" class="t">HttpRequest</span>) <span class="o">=</span> <span class="f">``method``</span> <span class="s">&quot;GET&quot;</span> <span onmouseout="hideTip(event, 'fs31', 45)" onmouseover="showTip(event, 'fs31', 45)" class="i">x</span>
<span class="k">let</span> <span onmouseout="hideTip(event, 'fs32', 46)" onmouseover="showTip(event, 'fs32', 46)" class="f">POST</span>    (<span onmouseout="hideTip(event, 'fs31', 47)" onmouseover="showTip(event, 'fs31', 47)" class="i">x</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs19', 48)" onmouseover="showTip(event, 'fs19', 48)" class="t">HttpRequest</span>) <span class="o">=</span> <span class="f">``method``</span> <span class="s">&quot;POST&quot;</span> <span onmouseout="hideTip(event, 'fs31', 49)" onmouseover="showTip(event, 'fs31', 49)" class="i">x</span>
<span class="k">let</span> <span onmouseout="hideTip(event, 'fs33', 50)" onmouseover="showTip(event, 'fs33', 50)" class="f">DELETE</span>  (<span onmouseout="hideTip(event, 'fs31', 51)" onmouseover="showTip(event, 'fs31', 51)" class="i">x</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs19', 52)" onmouseover="showTip(event, 'fs19', 52)" class="t">HttpRequest</span>) <span class="o">=</span> <span class="f">``method``</span> <span class="s">&quot;DELETE&quot;</span> <span onmouseout="hideTip(event, 'fs31', 53)" onmouseover="showTip(event, 'fs31', 53)" class="i">x</span>
<span class="k">let</span> <span onmouseout="hideTip(event, 'fs34', 54)" onmouseover="showTip(event, 'fs34', 54)" class="f">PUT</span>     (<span onmouseout="hideTip(event, 'fs31', 55)" onmouseover="showTip(event, 'fs31', 55)" class="i">x</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs19', 56)" onmouseover="showTip(event, 'fs19', 56)" class="t">HttpRequest</span>) <span class="o">=</span> <span class="f">``method``</span> <span class="s">&quot;PUT&quot;</span> <span onmouseout="hideTip(event, 'fs31', 57)" onmouseover="showTip(event, 'fs31', 57)" class="i">x</span>
<span class="k">let</span> <span onmouseout="hideTip(event, 'fs35', 58)" onmouseover="showTip(event, 'fs35', 58)" class="f">HEAD</span>    (<span onmouseout="hideTip(event, 'fs31', 59)" onmouseover="showTip(event, 'fs31', 59)" class="i">x</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs19', 60)" onmouseover="showTip(event, 'fs19', 60)" class="t">HttpRequest</span>) <span class="o">=</span> <span class="f">``method``</span> <span class="s">&quot;HEAD&quot;</span> <span onmouseout="hideTip(event, 'fs31', 61)" onmouseover="showTip(event, 'fs31', 61)" class="i">x</span>
<span class="k">let</span> <span onmouseout="hideTip(event, 'fs36', 62)" onmouseover="showTip(event, 'fs36', 62)" class="f">CONNECT</span> (<span onmouseout="hideTip(event, 'fs31', 63)" onmouseover="showTip(event, 'fs31', 63)" class="i">x</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs19', 64)" onmouseover="showTip(event, 'fs19', 64)" class="t">HttpRequest</span>) <span class="o">=</span> <span class="f">``method``</span> <span class="s">&quot;CONNECT&quot;</span> <span onmouseout="hideTip(event, 'fs31', 65)" onmouseover="showTip(event, 'fs31', 65)" class="i">x</span>
<span class="k">let</span> <span onmouseout="hideTip(event, 'fs37', 66)" onmouseover="showTip(event, 'fs37', 66)" class="f">PATCH</span>   (<span onmouseout="hideTip(event, 'fs31', 67)" onmouseover="showTip(event, 'fs31', 67)" class="i">x</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs19', 68)" onmouseover="showTip(event, 'fs19', 68)" class="t">HttpRequest</span>) <span class="o">=</span> <span class="f">``method``</span> <span class="s">&quot;PATCH&quot;</span> <span onmouseout="hideTip(event, 'fs31', 69)" onmouseover="showTip(event, 'fs31', 69)" class="i">x</span>
<span class="k">let</span> <span onmouseout="hideTip(event, 'fs38', 70)" onmouseover="showTip(event, 'fs38', 70)" class="f">TRACE</span>   (<span onmouseout="hideTip(event, 'fs31', 71)" onmouseover="showTip(event, 'fs31', 71)" class="i">x</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs19', 72)" onmouseover="showTip(event, 'fs19', 72)" class="t">HttpRequest</span>) <span class="o">=</span> <span class="f">``method``</span> <span class="s">&quot;TRACE&quot;</span> <span onmouseout="hideTip(event, 'fs31', 73)" onmouseover="showTip(event, 'fs31', 73)" class="i">x</span>
<span class="k">let</span> <span onmouseout="hideTip(event, 'fs39', 74)" onmouseover="showTip(event, 'fs39', 74)" class="f">OPTIONS</span> (<span onmouseout="hideTip(event, 'fs31', 75)" onmouseover="showTip(event, 'fs31', 75)" class="i">x</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs19', 76)" onmouseover="showTip(event, 'fs19', 76)" class="t">HttpRequest</span>) <span class="o">=</span> <span class="f">``method``</span> <span class="s">&quot;OPTIONS&quot;</span> <span onmouseout="hideTip(event, 'fs31', 77)" onmouseover="showTip(event, 'fs31', 77)" class="i">x</span>
</div></pre>

<h2>Server configuration</h2>
<p>The first argument to <code>startWebServer</code> is a configuration record with the
following signature. (See <a href="#changing-the-default-configuration">below</a> for tips
on customizing this.)</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="c">/// The core configuration of suave. See also Suave.Web.defaultConfig which</span>
<span class="c">/// you can use to bootstrap the configuration:</span>
<span class="c">/// &lt;code&gt;{ defaultConfig with bindings = [ ... ] }&lt;/code&gt;</span>
<span class="k">type</span> <span onmouseout="hideTip(event, 'fs40', 78)" onmouseover="showTip(event, 'fs40', 78)" class="t">SuaveConfig</span> <span class="o">=</span>
  { <span class="c">/// The bindings for the web server to launch with</span>
    <span onmouseout="hideTip(event, 'fs41', 79)" onmouseover="showTip(event, 'fs41', 79)" class="i">bindings</span>                <span class="o">:</span> <span onmouseout="hideTip(event, 'fs42', 80)" onmouseover="showTip(event, 'fs42', 80)" class="t">HttpBinding</span> <span onmouseout="hideTip(event, 'fs43', 81)" onmouseover="showTip(event, 'fs43', 81)" class="t">list</span>

    <span class="c">/// A server-key to use for cryptographic operations. When generated it</span>
    <span class="c">/// should be completely random; you can share this key between load-balanced</span>
    <span class="c">/// servers if you want to have them cryptographically verify similarly.</span>
    <span onmouseout="hideTip(event, 'fs44', 82)" onmouseover="showTip(event, 'fs44', 82)" class="i">serverKey</span>              <span class="o">:</span> <span onmouseout="hideTip(event, 'fs45', 83)" onmouseover="showTip(event, 'fs45', 83)" class="t">byte</span> []

    <span class="c">/// An error handler to use for handling exceptions that are</span>
    <span class="c">/// are thrown from the web parts</span>
    <span onmouseout="hideTip(event, 'fs46', 84)" onmouseover="showTip(event, 'fs46', 84)" class="i">errorHandler</span>           <span class="o">:</span> <span onmouseout="hideTip(event, 'fs1', 85)" onmouseover="showTip(event, 'fs1', 85)" class="t">ErrorHandler</span>

    <span class="c">/// Timeout to wait for the socket bind to finish</span>
    <span onmouseout="hideTip(event, 'fs47', 86)" onmouseover="showTip(event, 'fs47', 86)" class="i">listenTimeout</span>          <span class="o">:</span> <span class="i">TimeSpan</span>

    <span class="c">/// A cancellation token for the web server. Signalling this token</span>
    <span class="c">/// means that the web server shuts down</span>
    <span onmouseout="hideTip(event, 'fs48', 87)" onmouseover="showTip(event, 'fs48', 87)" class="i">cancellationToken</span>      <span class="o">:</span> <span class="i">Threading</span><span class="o">.</span><span class="i">CancellationToken</span>

    <span class="c">/// buffer size for socket operations</span>
    <span onmouseout="hideTip(event, 'fs49', 88)" onmouseover="showTip(event, 'fs49', 88)" class="i">bufferSize</span>             <span class="o">:</span> <span onmouseout="hideTip(event, 'fs50', 89)" onmouseover="showTip(event, 'fs50', 89)" class="t">int</span>

    <span class="c">/// Buffer manager auto grow</span>
    <span onmouseout="hideTip(event, 'fs51', 90)" onmouseover="showTip(event, 'fs51', 90)" class="i">autoGrow</span>               <span class="o">:</span> <span onmouseout="hideTip(event, 'fs28', 91)" onmouseover="showTip(event, 'fs28', 91)" class="t">bool</span>

    <span class="c">/// max number of concurrent socket operations</span>
    <span onmouseout="hideTip(event, 'fs52', 92)" onmouseover="showTip(event, 'fs52', 92)" class="i">maxOps</span>                 <span class="o">:</span> <span onmouseout="hideTip(event, 'fs50', 93)" onmouseover="showTip(event, 'fs50', 93)" class="t">int</span>

    <span class="c">/// MIME types</span>
    <span onmouseout="hideTip(event, 'fs53', 94)" onmouseover="showTip(event, 'fs53', 94)" class="i">mimeTypesMap</span>          <span class="o">:</span> <span onmouseout="hideTip(event, 'fs9', 95)" onmouseover="showTip(event, 'fs9', 95)" class="t">MimeTypesMap</span>

    <span class="c">/// Home or root directory</span>
    <span onmouseout="hideTip(event, 'fs54', 96)" onmouseover="showTip(event, 'fs54', 96)" class="i">homeFolder</span>             <span class="o">:</span> <span onmouseout="hideTip(event, 'fs11', 97)" onmouseover="showTip(event, 'fs11', 97)" class="t">string</span> <span onmouseout="hideTip(event, 'fs55', 98)" onmouseover="showTip(event, 'fs55', 98)" class="t">option</span>

    <span class="c">/// Folder for temporary compressed files</span>
    <span onmouseout="hideTip(event, 'fs56', 99)" onmouseover="showTip(event, 'fs56', 99)" class="i">compressedFilesFolder</span>  <span class="o">:</span> <span onmouseout="hideTip(event, 'fs11', 100)" onmouseover="showTip(event, 'fs11', 100)" class="t">string</span> <span onmouseout="hideTip(event, 'fs55', 101)" onmouseover="showTip(event, 'fs55', 101)" class="t">option</span>

    <span class="c">/// Suave&#39;s logger. You can override the default instance if you wish to</span>
    <span class="c">/// ship your logs, e.g. using https://www.nuget.org/packages/Logary.Adapters.Suave/</span>
    <span class="c">/// Also, this logger will be configured by default for Suave unless you</span>
    <span class="c">/// explicitly use `Suave.Logging.Global.initialise` before starting the</span>
    <span class="c">/// web server (the first time – the second time, the static will already</span>
    <span class="c">/// have been initialised).</span>
    <span onmouseout="hideTip(event, 'fs57', 102)" onmouseover="showTip(event, 'fs57', 102)" class="i">logger</span>                <span class="o">:</span> <span onmouseout="hideTip(event, 'fs15', 103)" onmouseover="showTip(event, 'fs15', 103)" class="t">Logger</span>

    <span class="c">/// Pluggable TCP async sockets implementation. You can choose betwee libuv</span>
    <span class="c">/// and CLR&#39;s Async Socket Event Args. Currently defaults to the managed-only</span>
    <span class="c">/// implementation.</span>
    <span onmouseout="hideTip(event, 'fs58', 104)" onmouseover="showTip(event, 'fs58', 104)" class="i">tcpServerFactory</span>      <span class="o">:</span> <span onmouseout="hideTip(event, 'fs59', 105)" onmouseover="showTip(event, 'fs59', 105)" class="t">TcpServerFactory</span>

    <span class="c">/// The cookie serialiser to use for converting the data you save in cookies</span>
    <span class="c">/// from your application into a byte array.</span>
    <span onmouseout="hideTip(event, 'fs60', 106)" onmouseover="showTip(event, 'fs60', 106)" class="i">cookieSerialiser</span>      <span class="o">:</span> <span onmouseout="hideTip(event, 'fs61', 107)" onmouseover="showTip(event, 'fs61', 107)" class="t">CookieSerialiser</span>

    <span class="c">/// A TLS provider implementation.</span>
    <span onmouseout="hideTip(event, 'fs62', 108)" onmouseover="showTip(event, 'fs62', 108)" class="i">tlsProvider</span>           <span class="o">:</span> <span onmouseout="hideTip(event, 'fs63', 109)" onmouseover="showTip(event, 'fs63', 109)" class="t">TlsProvider</span>

    <span class="c">/// Make this true, if you want Suave not to display its server header in</span>
    <span class="c">/// every response. Defaults to false.</span>
    <span onmouseout="hideTip(event, 'fs64', 110)" onmouseover="showTip(event, 'fs64', 110)" class="i">hideHeader</span>            <span class="o">:</span> <span onmouseout="hideTip(event, 'fs28', 111)" onmouseover="showTip(event, 'fs28', 111)" class="t">bool</span>

    <span class="c">/// Maximun upload size in bytes</span>
    <span onmouseout="hideTip(event, 'fs65', 112)" onmouseover="showTip(event, 'fs65', 112)" class="i">maxContentLength</span>      <span class="o">:</span> <span onmouseout="hideTip(event, 'fs50', 113)" onmouseover="showTip(event, 'fs50', 113)" class="t">int</span> }
</div></pre>

<p>With <code>Protocol</code> , <code>HttpBinding</code> and <code>MimeType</code> defined like follows:</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">type</span> <span onmouseout="hideTip(event, 'fs66', 114)" onmouseover="showTip(event, 'fs66', 114)" class="t">ITlsProvider</span> <span class="o">=</span>
  <span class="k">abstract</span> <span class="k">member</span> <span onmouseout="hideTip(event, 'fs67', 115)" onmouseover="showTip(event, 'fs67', 115)" class="f">Wrap</span>  <span class="o">:</span> <span class="i">Connection</span> <span class="k">-&gt;</span> <span class="i">SocketOp</span><span class="o">&lt;</span><span class="i">Connection</span><span class="o">&gt;</span>

<span class="c">/// Gets the supported protocols, HTTP and HTTPS with a certificate</span>
<span class="k">type</span> <span onmouseout="hideTip(event, 'fs68', 116)" onmouseover="showTip(event, 'fs68', 116)" class="t">Protocol</span> <span class="o">=</span>
  <span class="c">/// The HTTP protocol is the core protocol</span>
  | <span onmouseout="hideTip(event, 'fs69', 117)" onmouseover="showTip(event, 'fs69', 117)" class="p">HTTP</span>
  <span class="c">/// The HTTP protocol tunneled in a TLS tunnel</span>
  | <span onmouseout="hideTip(event, 'fs70', 118)" onmouseover="showTip(event, 'fs70', 118)" class="p">HTTPS</span> <span class="k">of</span> <span onmouseout="hideTip(event, 'fs66', 119)" onmouseover="showTip(event, 'fs66', 119)" class="t">ITlsProvider</span>

<span class="c">/// A HTTP binding is a protocol is the product of HTTP or HTTP, a DNS or IP binding</span>
<span class="c">/// and a port number</span>
<span class="k">type</span> <span onmouseout="hideTip(event, 'fs71', 120)" onmouseover="showTip(event, 'fs71', 120)" class="t">HttpBinding</span> <span class="o">=</span>
  <span class="c">/// The scheme in use</span>
  { <span onmouseout="hideTip(event, 'fs72', 121)" onmouseover="showTip(event, 'fs72', 121)" class="i">scheme</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs68', 122)" onmouseover="showTip(event, 'fs68', 122)" class="t">Protocol</span>
    <span class="c">/// The host or IP address to bind to. This will be interpreted by the operating system</span>
    <span onmouseout="hideTip(event, 'fs73', 123)" onmouseover="showTip(event, 'fs73', 123)" class="i">ip</span>     <span class="o">:</span> <span class="i">IPAddress</span>
    <span class="c">/// The port for the binding</span>
    <span onmouseout="hideTip(event, 'fs74', 124)" onmouseover="showTip(event, 'fs74', 124)" class="i">port</span>   <span class="o">:</span> <span onmouseout="hideTip(event, 'fs75', 125)" onmouseover="showTip(event, 'fs75', 125)" class="t">uint16</span> }

<span class="k">type</span> <span onmouseout="hideTip(event, 'fs76', 126)" onmouseover="showTip(event, 'fs76', 126)" class="t">MimeType</span> <span class="o">=</span>
  <span class="c">/// The name of the mime type, i.e &quot;text/plain&quot;</span>
  { <span onmouseout="hideTip(event, 'fs77', 127)" onmouseover="showTip(event, 'fs77', 127)" class="i">name</span>         <span class="o">:</span> <span onmouseout="hideTip(event, 'fs11', 128)" onmouseover="showTip(event, 'fs11', 128)" class="t">string</span>
    <span class="c">/// If the server will compress the file when clients ask for gzip or</span>
    <span class="c">/// deflate in the `Accept-Encoding` header</span>
    <span onmouseout="hideTip(event, 'fs78', 129)" onmouseover="showTip(event, 'fs78', 129)" class="i">compression</span>  <span class="o">:</span> <span onmouseout="hideTip(event, 'fs28', 130)" onmouseover="showTip(event, 'fs28', 130)" class="t">bool</span> }
</div></pre>

<h2>Overview</h2>
<p>A request life-cycle begins with the <code>HttpProcessor</code> that takes an <code>HttpRequest</code>
and the request as bytes and starts parsing it. It returns an <code>HttpRequest
option</code> that, if Some, gets run against the WebParts passed.</p>
<h3>The WebPart</h3>
<p>A web part is a thing that acts on a HttpContext, the web part could fail by
returning <code>None</code> or succeed and produce a new HttpContext. Each web part can
execute asynchronously, and it's not until it is evaluated that the async is
evaluated. It will be evaluated on the same fibre (asynchronous execution
context) that is consuming from the browser's TCP socket.</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">type</span> <span onmouseout="hideTip(event, 'fs79', 131)" onmouseover="showTip(event, 'fs79', 131)" class="t">SuaveTask</span><span class="o">&lt;</span><span class="o">&#39;</span><span class="i">a</span><span class="o">&gt;</span> <span class="o">=</span> <span onmouseout="hideTip(event, 'fs80', 132)" onmouseover="showTip(event, 'fs80', 132)" class="t">Async</span><span class="o">&lt;</span><span class="o">&#39;</span><span class="i">a</span> <span onmouseout="hideTip(event, 'fs55', 133)" onmouseover="showTip(event, 'fs55', 133)" class="t">option</span><span class="o">&gt;</span>
<span class="k">type</span> <span onmouseout="hideTip(event, 'fs81', 134)" onmouseover="showTip(event, 'fs81', 134)" class="t">WebPart</span> <span class="o">=</span> <span onmouseout="hideTip(event, 'fs3', 135)" onmouseover="showTip(event, 'fs3', 135)" class="t">HttpContext</span> <span class="k">-&gt;</span> <span onmouseout="hideTip(event, 'fs79', 136)" onmouseover="showTip(event, 'fs79', 136)" class="t">SuaveTask</span><span class="o">&lt;</span><span onmouseout="hideTip(event, 'fs3', 137)" onmouseover="showTip(event, 'fs3', 137)" class="t">HttpContext</span><span class="o">&gt;</span>
<span class="c">// hence: WebPart = HttpContext -&gt; Async&lt;HttpContext option&gt;</span>
</div></pre>

<h3>The ErrorHandler</h3>
<p>An error handler takes the exception, a programmer-provided message, a request
(that failed) and returns a web part for the handling of the
error.</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="c">/// An error handler takes the exception, a programmer-provided message, a</span>
<span class="c">/// request (that failed) and returns</span>
<span class="c">/// an asynchronous workflow for the handling of the error.</span>
<span class="k">type</span> <span onmouseout="hideTip(event, 'fs1', 138)" onmouseover="showTip(event, 'fs1', 138)" class="i">ErrorHandler</span> <span class="o">=</span> <span class="i">Exception</span> <span class="k">-&gt;</span> <span onmouseout="hideTip(event, 'fs2', 139)" onmouseover="showTip(event, 'fs2', 139)" class="i">String</span> <span class="k">-&gt;</span> <span onmouseout="hideTip(event, 'fs81', 140)" onmouseover="showTip(event, 'fs81', 140)" class="i">WebPart</span>
</div></pre>

<h3>Changing the Default Configuration</h3>
<p><code>defaultConfig</code> (defined in <code>Suave.Web</code>) has sane defaults, and for many users,
these will be fine. However, since <code>SuaveConfig</code> is a record type, it is easy
to swap out one or more of the default settings, tweaking the configuration to
your precise needs. While we will discuss the default values below, you can
review the defaults at the bottom of
<a href="https://github.com/SuaveIO/suave/blob/master/src/Suave/Web.fs">Web.fs</a>.</p>
<p>If you're looking to get started quickly, you can jump straight to sections
detailing how to
<a href="#changing-the-servers-ip-address-or-port">change the IP addres or port</a>,
<a href="#changing-the-home-folder">specify a home directory</a>, and
<a href="#changing-the-servers-cryptography-key">set the server's cryptography key</a>. For
those whose descriptions are prefixed with "<em>(advanced)</em>", there is the
potential to degrade Suave's performance; you should take great care when
changing these from their default values.</p>
<h4>Changing the server's IP address or port</h4>
<p>The default binding for Suave is <a href="http://127.0.0.1:8080.">http://127.0.0.1:8080.</a> It is rather simple to
change that, though.</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">let</span> <span onmouseout="hideTip(event, 'fs82', 141)" onmouseover="showTip(event, 'fs82', 141)" class="i">myCfg</span> <span class="o">=</span>
  { <span onmouseout="hideTip(event, 'fs83', 142)" onmouseover="showTip(event, 'fs83', 142)" class="i">defaultConfig</span> <span class="k">with</span>
      <span class="i">bindings</span> <span class="o">=</span> [ <span onmouseout="hideTip(event, 'fs71', 143)" onmouseover="showTip(event, 'fs71', 143)" class="t">HttpBinding</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs84', 144)" onmouseover="showTip(event, 'fs84', 144)" class="f">createSimple</span> <span onmouseout="hideTip(event, 'fs69', 145)" onmouseover="showTip(event, 'fs69', 145)" class="p">HTTP</span> <span class="s">&quot;127.0.0.1&quot;</span> <span class="n">8082</span> ]
    }
</div></pre>

<p>As <code>bindings</code> is a list, you can also configure Suave to listen on any
combination of IP addresses and ports.</p>
<h4>Changing the server's cryptography key</h4>
<p>Suave encrypts state stored in <a href="sessions.html">sessions</a>, and the key used for
that is the <code>serverKey</code> configuration setting. This key is required to be a
specific length (256 bits as of this writing), so there is a <code>ServerKey</code> module
that helps ensure that the key is the proper length.  The importance of this
key, how to generate one, and how to plug it into your Suave config can be found
under the <a href="/sessions.html#server-keys">Server Keys</a> heading on that page.</p>
<p>While the examples all demonstrate using a base64-encoded string, if you have
256 bits already in a byte array that you want to use as a server key, you can
use <code>ServerKey.validate</code> instead of <code>ServerKey.fromBase64</code>; it will ensure that
the key is the proper length.</p>
<h4>Changing the error handler</h4>
<p>Suave's default error handler logs the error, then returns an HTTP 500
response. For local requests, it returns the error and stack trace in the body
of the response; for others, it returns "Internal Server Error". The best way
to customize it would be to start with <code>defaultErrorHandler</code>
<a href="https://github.com/SuaveIO/suave/blob/master/src/Suave/Web.fs">near the top of Web.fs</a>,
and tweak it to your liking. Then...</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">let</span> <span onmouseout="hideTip(event, 'fs82', 146)" onmouseover="showTip(event, 'fs82', 146)" class="i">myCfg</span> <span class="o">=</span>
  { <span onmouseout="hideTip(event, 'fs83', 147)" onmouseover="showTip(event, 'fs83', 147)" class="i">defaultConfig</span> <span class="k">with</span>
      <span class="i">errorHandler</span> <span class="o">=</span> <span class="i">myErrorHandler</span>
    }
</div></pre>

<h4>Changing the listen timeout</h4>
<p><em>(advanced)</em> This is the <code>TimeSpan</code> Suave will wait, on startup, for its request
to bind to a specific TCP port to be successful. The default value is for
<code>listenTimeout</code> is 2 seconds.</p>
<h4>Changing the cancellation token</h4>
<p>As with any asynchronous process, Suave can be controlled by the cancellation
token used to start the process. By default, it uses the default cancellation
token; however, giving <code>cancellationToken</code> a specific value here will allow for
scenarios such as stopping and restarting Suave programmatically.</p>
<h4>Changing the buffer size</h4>
<p><em>(advanced)</em> The <code>bufferSize</code> that is used for socket operations (low-level
communications). Its default value is 8192 bytes (8KB).</p>
<h4>Changing whether the buffer can automatically grow</h4>
<p><em>(advanced)</em> This boolean specifies whether the buffer manager is allowed to
grow itself; <code>autoGrow</code> defaults to <code>true</code>.</p>
<h4>Changing the maximum concurrent operations</h4>
<p><em>(advanced)</em> This is the maximum number of concurrent socket operations that
Suave will attempt to serve. The default value for <code>maxOps</code> is 100.</p>
<h4>Changing the MIME type map</h4>
<p>The <code>Writers</code> module has a default MIME type map, and that is the default map
in the configuration.  Suave will not serve a file for which it cannot determine
a MIME type, so if you are serving files that are not
<a href="https://github.com/SuaveIO/suave/blob/master/src/Suave/Combinators.fs#L90">current in the MIME type map</a>,
you will need to add this type.</p>
<p>The above paragraph uses the word "map" several times, but it's technically a
mapping function; to modify it, you need a function of your own.  As of this
writing, .iso files are not in the default mapping.  Here's how we could add it.</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">let</span> <span onmouseout="hideTip(event, 'fs85', 148)" onmouseover="showTip(event, 'fs85', 148)" class="f">myMimeTypesMap</span> <span onmouseout="hideTip(event, 'fs86', 149)" onmouseover="showTip(event, 'fs86', 149)" class="i">ext</span> <span class="o">=</span>
  <span class="k">match</span> <span onmouseout="hideTip(event, 'fs87', 150)" onmouseover="showTip(event, 'fs87', 150)" class="t">Writers</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs88', 151)" onmouseover="showTip(event, 'fs88', 151)" class="f">defaultMimeTypesMap</span> <span onmouseout="hideTip(event, 'fs86', 152)" onmouseover="showTip(event, 'fs86', 152)" class="i">ext</span> <span class="k">with</span>
  | <span onmouseout="hideTip(event, 'fs89', 153)" onmouseover="showTip(event, 'fs89', 153)" class="p">Some</span> <span onmouseout="hideTip(event, 'fs90', 154)" onmouseover="showTip(event, 'fs90', 154)" class="i">mime</span> <span class="k">-&gt;</span> <span onmouseout="hideTip(event, 'fs90', 155)" onmouseover="showTip(event, 'fs90', 155)" class="i">mime</span>
  | _ <span class="k">-&gt;</span>
      <span class="k">match</span> <span onmouseout="hideTip(event, 'fs86', 156)" onmouseover="showTip(event, 'fs86', 156)" class="i">ext</span> <span class="k">with</span>
      | <span class="s">&quot;.iso&quot;</span> <span class="k">-&gt;</span> <span class="i">createMimeType</span> <span class="s">&quot;application/octet-stream&quot;</span> <span class="k">false</span>
      | _ <span class="k">-&gt;</span> <span onmouseout="hideTip(event, 'fs91', 157)" onmouseover="showTip(event, 'fs91', 157)" class="p">None</span>

<span class="c">// and then</span>

<span class="k">let</span> <span onmouseout="hideTip(event, 'fs82', 158)" onmouseover="showTip(event, 'fs82', 158)" class="i">myCfg</span> <span class="o">=</span>
  { <span onmouseout="hideTip(event, 'fs83', 159)" onmouseover="showTip(event, 'fs83', 159)" class="i">defaultConfig</span> <span class="k">with</span>
      <span class="i">mimeTypesMap</span> <span class="o">=</span> <span onmouseout="hideTip(event, 'fs85', 160)" onmouseover="showTip(event, 'fs85', 160)" class="f">myMimeTypesMap</span>
    }
</div></pre>

<h4>Changing the home folder</h4>
<p>Suave does not have a default home folder.  If you want to serve files from
a folder, just specify it as a <code>Some</code> string.  If an absolute path is not given,
it is interpreted from the current working directory when Suave was started.
For example, if we follow the .NET Core convention of putting our
publicly-available files under <code>wwwroot</code>, this example sets it as the home
folder.</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">let</span> <span onmouseout="hideTip(event, 'fs82', 161)" onmouseover="showTip(event, 'fs82', 161)" class="i">myCfg</span> <span class="o">=</span>
  { <span onmouseout="hideTip(event, 'fs83', 162)" onmouseover="showTip(event, 'fs83', 162)" class="i">defaultConfig</span> <span class="k">with</span>
      <span class="i">homeFolder</span> <span class="o">=</span> <span onmouseout="hideTip(event, 'fs89', 163)" onmouseover="showTip(event, 'fs89', 163)" class="p">Some</span> <span class="s">&quot;./wwwroot&quot;</span>
    }
</div></pre>

<h4>Changing the compressed files folder</h4>
<p>Suave writes temporary files to disk when performing compression; the default
directory where these files are placed is the current working directory when
Suave was started.  However, if you want these files to go somewhere specific,
you can specify them the exact same way we did above for the home folder; just
set the <code>compressedFilesFolder</code> field instead.  (Suave deletes these files once
they are served, so their lifetime is usually less than a second.)</p>
<h4>Changing logging options</h4>
<p>A good overview can be found <a href="logs.html">on the logging page</a>.</p>
<h4>Changing the default TCP server</h4>
<p>Suave's default TCP server uses the .NET CLR's socket implementation to bind
and listen. Suave also comes with a TCP server implementation based on
<a href="https://github.com/libuv/libuv">LibUV</a>; to use it...</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">open</span> <span onmouseout="hideTip(event, 'fs92', 164)" onmouseover="showTip(event, 'fs92', 164)" class="i">Suave</span><span class="o">.</span><span class="i">LibUv</span>

<span class="k">let</span> <span onmouseout="hideTip(event, 'fs82', 165)" onmouseover="showTip(event, 'fs82', 165)" class="i">myCfg</span> <span class="o">=</span>
  { <span onmouseout="hideTip(event, 'fs83', 166)" onmouseover="showTip(event, 'fs83', 166)" class="i">defaultConfig</span> <span class="k">with</span>
      <span class="i">tcpServerFactory</span> <span class="o">=</span> <span class="k">new</span> <span class="i">LibUvServerFactory</span>()
    }
</div></pre>

<h4>Changing the default cookie serializer</h4>
<p>By default, Suave uses a binary formatter to serialize a <code>Map&lt;string, obj&gt;</code>
into a string that is encrypted and used as a cookie payload. On the "State and
Sessions" page, there is an
<a href="/sessions.html#cookie-serializationbrof-particular-interest-to-net-core--netstandard20">example of swapping out the default cookie serializer for one based on JSON.NET</a>.</p>
<h4>Changing the default TLS provider</h4>
<p><em>(advanced)</em> The TLS provider supports encrypted communications (HTTPS). The
default is an instance of the <code>DefaultTlsProvider</code> class; customizing it would
require implementing the <code>TlsProvider</code> interface, and providing an instance of
that class in your configuration's <code>tlsProvider</code> field.</p>
<h4>Changing whether the header is shown</h4>
<p>By default, Suave adds a <code>Server</code> header to each response, identifying itself
as the software that handled the request. If this behavior is not desired, you
can set <code>hideHeader</code> to <code>true</code>.</p>
<h4>Changing the maximum file upload size</h4>
<p>The <code>maxContentLength</code> field controls the maximum allowed upload size, in bytes;
its default is 10000000 (10 MiB).</p>


<div class="tip" id="fs1">type ErrorHandler = obj -&gt; obj -&gt; HttpContext -&gt; HttpContext<br /><br />Full name: temp.ErrorHandler</div>
<div class="tip" id="fs2">Multiple items<br />module String<br /><br />from YoLo<br /><br />--------------------<br />module String<br /><br />from Microsoft.FSharp.Core</div>
<div class="tip" id="fs3">Multiple items<br />module HttpContext<br /><br />from Suave.Http<br /><br />--------------------<br />type HttpContext =<br />&#160;&#160;{request: HttpRequest;<br />&#160;&#160;&#160;runtime: HttpRuntime;<br />&#160;&#160;&#160;userState: Map&lt;string,obj&gt;;<br />&#160;&#160;&#160;response: HttpResult;}<br /><br />Full name: temp.HttpContext</div>
<div class="tip" id="fs4">Multiple items<br />module HttpRuntime<br /><br />from Suave.Http<br /><br />--------------------<br />type HttpRuntime =<br />&#160;&#160;{protocol: Protocol;<br />&#160;&#160;&#160;errorHandler: ErrorHandler;<br />&#160;&#160;&#160;mimeTypesMap: MimeTypesMap;<br />&#160;&#160;&#160;homeDirectory: string;<br />&#160;&#160;&#160;compressionFolder: string;<br />&#160;&#160;&#160;logger: obj;<br />&#160;&#160;&#160;sessionProvider: ISessionProvider;}<br /><br />Full name: temp.HttpRuntime</div>
<div class="tip" id="fs5">HttpRuntime.protocol: Protocol</div>
<div class="tip" id="fs6">type Protocol =<br />&#160;&#160;| HTTP<br />&#160;&#160;| HTTPS of obj<br />&#160;&#160;member secure : bool<br /><br />Full name: Suave.Http.Protocol</div>
<div class="tip" id="fs7">HttpRuntime.errorHandler: ErrorHandler</div>
<div class="tip" id="fs8">HttpRuntime.mimeTypesMap: MimeTypesMap</div>
<div class="tip" id="fs9">type MimeTypesMap = string -&gt; MimeType option<br /><br />Full name: Suave.Http.MimeTypesMap</div>
<div class="tip" id="fs10">HttpRuntime.homeDirectory: string</div>
<div class="tip" id="fs11">Multiple items<br />val string : value:&#39;T -&gt; string<br /><br />Full name: Microsoft.FSharp.Core.Operators.string<br /><br />--------------------<br />type string = System.String<br /><br />Full name: Microsoft.FSharp.Core.string</div>
<div class="tip" id="fs12">HttpRuntime.compressionFolder: string</div>
<div class="tip" id="fs13">HttpRuntime.logger: obj</div>
<div class="tip" id="fs14">module Log<br /><br />from Suave.Logging</div>
<div class="tip" id="fs15">type Logger =<br />&#160;&#160;interface<br />&#160;&#160;&#160;&#160;abstract member name : string []<br />&#160;&#160;&#160;&#160;abstract member log : LogLevel -&gt; (LogLevel -&gt; Message) -&gt; Async&lt;unit&gt;<br />&#160;&#160;&#160;&#160;abstract member logWithAck : LogLevel -&gt; (LogLevel -&gt; Message) -&gt; Async&lt;unit&gt;<br />&#160;&#160;end<br /><br />Full name: Suave.Logging.Logger</div>
<div class="tip" id="fs16">HttpRuntime.sessionProvider: ISessionProvider</div>
<div class="tip" id="fs17">type ISessionProvider =<br />&#160;&#160;interface<br />&#160;&#160;&#160;&#160;abstract member Generate : &#39;a0 * HttpContext -&gt; string<br />&#160;&#160;&#160;&#160;abstract member Session : string -&gt; obj<br />&#160;&#160;&#160;&#160;abstract member Validate : string * HttpContext -&gt; bool<br />&#160;&#160;end<br /><br />Full name: temp.ISessionProvider</div>
<div class="tip" id="fs18">HttpContext.request: HttpRequest</div>
<div class="tip" id="fs19">Multiple items<br />module HttpRequest<br /><br />from Suave.Http<br /><br />--------------------<br />type HttpRequest =<br />&#160;&#160;{httpVersion: string;<br />&#160;&#160;&#160;url: Uri;<br />&#160;&#160;&#160;host: Host;<br />&#160;&#160;&#160;method: HttpMethod;<br />&#160;&#160;&#160;headers: (string * string) list;<br />&#160;&#160;&#160;rawForm: byte [];<br />&#160;&#160;&#160;rawQuery: string;<br />&#160;&#160;&#160;files: HttpUpload list;<br />&#160;&#160;&#160;multiPartFields: (string * string) list;<br />&#160;&#160;&#160;trace: TraceHeader;}<br />&#160;&#160;member clientHost : trustProxy:bool -&gt; sources:string list -&gt; Host<br />&#160;&#160;member fieldData : key:string -&gt; Choice&lt;string,string&gt;<br />&#160;&#160;member formData : key:string -&gt; Choice&lt;string,string&gt;<br />&#160;&#160;member Item : key:string -&gt; string option with get<br />&#160;&#160;member clientHostTrustProxy : Host<br />&#160;&#160;member form : (string * string option) list<br />&#160;&#160;member path : string<br />&#160;&#160;member query : (string * string option) list<br />&#160;&#160;member header : key:string -&gt; Choice&lt;string,string&gt;<br />&#160;&#160;member queryFlag : flag:string -&gt; bool<br />&#160;&#160;member queryParam : key:string -&gt; Choice&lt;string,string&gt;<br />&#160;&#160;member queryParamOpt : key:string -&gt; (string * string option) option<br />&#160;&#160;static member files_ : Property&lt;HttpRequest,HttpUpload list&gt;<br />&#160;&#160;static member headers_ : Property&lt;HttpRequest,(string * string) list&gt;<br />&#160;&#160;static member host_ : Property&lt;HttpRequest,Host&gt;<br />&#160;&#160;static member httpVersion_ : Property&lt;HttpRequest,string&gt;<br />&#160;&#160;static member method_ : Property&lt;HttpRequest,HttpMethod&gt;<br />&#160;&#160;static member multipartFields_ : Property&lt;HttpRequest,(string * string) list&gt;<br />&#160;&#160;static member rawForm_ : Property&lt;HttpRequest,byte []&gt;<br />&#160;&#160;static member rawQuery_ : Property&lt;HttpRequest,string&gt;<br />&#160;&#160;static member trace_ : Property&lt;HttpRequest,TraceHeader&gt;<br />&#160;&#160;static member url_ : Property&lt;HttpRequest,Uri&gt;<br /><br />Full name: Suave.Http.HttpRequest</div>
<div class="tip" id="fs20">HttpContext.runtime: HttpRuntime</div>
<div class="tip" id="fs21">HttpContext.userState: Map&lt;string,obj&gt;</div>
<div class="tip" id="fs22">Multiple items<br />module Map<br /><br />from YoLo<br /><br />--------------------<br />module Map<br /><br />from Microsoft.FSharp.Collections<br /><br />--------------------<br />type Map&lt;&#39;Key,&#39;Value (requires comparison)&gt; =<br />&#160;&#160;interface IEnumerable<br />&#160;&#160;interface IComparable<br />&#160;&#160;interface IEnumerable&lt;KeyValuePair&lt;&#39;Key,&#39;Value&gt;&gt;<br />&#160;&#160;interface ICollection&lt;KeyValuePair&lt;&#39;Key,&#39;Value&gt;&gt;<br />&#160;&#160;interface IDictionary&lt;&#39;Key,&#39;Value&gt;<br />&#160;&#160;new : elements:seq&lt;&#39;Key * &#39;Value&gt; -&gt; Map&lt;&#39;Key,&#39;Value&gt;<br />&#160;&#160;member Add : key:&#39;Key * value:&#39;Value -&gt; Map&lt;&#39;Key,&#39;Value&gt;<br />&#160;&#160;member ContainsKey : key:&#39;Key -&gt; bool<br />&#160;&#160;override Equals : obj -&gt; bool<br />&#160;&#160;member Remove : key:&#39;Key -&gt; Map&lt;&#39;Key,&#39;Value&gt;<br />&#160;&#160;...<br /><br />Full name: Microsoft.FSharp.Collections.Map&lt;_,_&gt;<br /><br />--------------------<br />new : elements:seq&lt;&#39;Key * &#39;Value&gt; -&gt; Map&lt;&#39;Key,&#39;Value&gt;</div>
<div class="tip" id="fs23">type obj = System.Object<br /><br />Full name: Microsoft.FSharp.Core.obj</div>
<div class="tip" id="fs24">HttpContext.response: HttpResult</div>
<div class="tip" id="fs25">Multiple items<br />module HttpResult<br /><br />from Suave.Http<br /><br />--------------------<br />type HttpResult =<br />&#160;&#160;{status: HttpStatus;<br />&#160;&#160;&#160;headers: (string * string) list;<br />&#160;&#160;&#160;content: HttpContent;<br />&#160;&#160;&#160;writePreamble: bool;}<br />&#160;&#160;static member content_ : Property&lt;HttpResult,HttpContent&gt;<br />&#160;&#160;static member headers_ : Property&lt;HttpResult,(string * string) list&gt;<br />&#160;&#160;static member status_ : Property&lt;HttpResult,HttpStatus&gt;<br />&#160;&#160;static member writePreamble_ : Property&lt;HttpResult,bool&gt;<br /><br />Full name: Suave.Http.HttpResult</div>
<div class="tip" id="fs26">abstract member ISessionProvider.Generate : &#39;a0 * HttpContext -&gt; string<br /><br />Full name: temp.ISessionProvider.Generate</div>
<div class="tip" id="fs27">abstract member ISessionProvider.Validate : string * HttpContext -&gt; bool<br /><br />Full name: temp.ISessionProvider.Validate</div>
<div class="tip" id="fs28">type bool = System.Boolean<br /><br />Full name: Microsoft.FSharp.Core.bool</div>
<div class="tip" id="fs29">abstract member ISessionProvider.Session : string -&gt; obj<br /><br />Full name: temp.ISessionProvider.Session</div>
<div class="tip" id="fs30">val GET : x:HttpRequest -&gt; Async&lt;HttpContext option&gt;<br /><br />Full name: temp.GET</div>
<div class="tip" id="fs31">val x : HttpRequest</div>
<div class="tip" id="fs32">val POST : x:HttpRequest -&gt; Async&lt;HttpContext option&gt;<br /><br />Full name: temp.POST</div>
<div class="tip" id="fs33">val DELETE : x:HttpRequest -&gt; Async&lt;HttpContext option&gt;<br /><br />Full name: temp.DELETE</div>
<div class="tip" id="fs34">val PUT : x:HttpRequest -&gt; Async&lt;HttpContext option&gt;<br /><br />Full name: temp.PUT</div>
<div class="tip" id="fs35">val HEAD : x:HttpRequest -&gt; Async&lt;HttpContext option&gt;<br /><br />Full name: temp.HEAD</div>
<div class="tip" id="fs36">val CONNECT : x:HttpRequest -&gt; Async&lt;HttpContext option&gt;<br /><br />Full name: temp.CONNECT</div>
<div class="tip" id="fs37">val PATCH : x:HttpRequest -&gt; Async&lt;HttpContext option&gt;<br /><br />Full name: temp.PATCH</div>
<div class="tip" id="fs38">val TRACE : x:HttpRequest -&gt; Async&lt;HttpContext option&gt;<br /><br />Full name: temp.TRACE</div>
<div class="tip" id="fs39">val OPTIONS : x:HttpRequest -&gt; Async&lt;HttpContext option&gt;<br /><br />Full name: temp.OPTIONS</div>
<div class="tip" id="fs40">Multiple items<br />module SuaveConfig<br /><br />from Suave<br /><br />--------------------<br />type SuaveConfig =<br />&#160;&#160;{bindings: HttpBinding list;<br />&#160;&#160;&#160;serverKey: byte [];<br />&#160;&#160;&#160;errorHandler: ErrorHandler;<br />&#160;&#160;&#160;listenTimeout: obj;<br />&#160;&#160;&#160;cancellationToken: obj;<br />&#160;&#160;&#160;bufferSize: int;<br />&#160;&#160;&#160;autoGrow: bool;<br />&#160;&#160;&#160;maxOps: int;<br />&#160;&#160;&#160;mimeTypesMap: MimeTypesMap;<br />&#160;&#160;&#160;homeFolder: string option;<br />&#160;&#160;&#160;...}<br /><br />Full name: temp.SuaveConfig<br /><em><br /><br />&#160;The core configuration of suave. See also Suave.Web.defaultConfig which<br />&#160;you can use to bootstrap the configuration:<br />&#160;&lt;code&gt;{ defaultConfig with bindings = [ ... ] }&lt;/code&gt;</em></div>
<div class="tip" id="fs41">SuaveConfig.bindings: HttpBinding list<br /><em><br /><br />&#160;The bindings for the web server to launch with</em></div>
<div class="tip" id="fs42">Multiple items<br />module HttpBinding<br /><br />from Suave.Http<br /><br />--------------------<br />type HttpBinding =<br />&#160;&#160;{scheme: Protocol;<br />&#160;&#160;&#160;socketBinding: SocketBinding;}<br />&#160;&#160;override ToString : unit -&gt; string<br />&#160;&#160;member uri : path:string -&gt; query:string -&gt; Uri<br />&#160;&#160;static member scheme_ : Property&lt;HttpBinding,Protocol&gt;<br />&#160;&#160;static member socketBinding_ : Property&lt;HttpBinding,SocketBinding&gt;<br /><br />Full name: Suave.Http.HttpBinding</div>
<div class="tip" id="fs43">type &#39;T list = List&lt;&#39;T&gt;<br /><br />Full name: Microsoft.FSharp.Collections.list&lt;_&gt;</div>
<div class="tip" id="fs44">SuaveConfig.serverKey: byte []<br /><em><br /><br />&#160;A server-key to use for cryptographic operations. When generated it<br />&#160;should be completely random; you can share this key between load-balanced<br />&#160;servers if you want to have them cryptographically verify similarly.</em></div>
<div class="tip" id="fs45">Multiple items<br />val byte : value:&#39;T -&gt; byte (requires member op_Explicit)<br /><br />Full name: Microsoft.FSharp.Core.Operators.byte<br /><br />--------------------<br />type byte = System.Byte<br /><br />Full name: Microsoft.FSharp.Core.byte</div>
<div class="tip" id="fs46">SuaveConfig.errorHandler: ErrorHandler<br /><em><br /><br />&#160;An error handler to use for handling exceptions that are<br />&#160;are thrown from the web parts</em></div>
<div class="tip" id="fs47">SuaveConfig.listenTimeout: obj<br /><em><br /><br />&#160;Timeout to wait for the socket bind to finish</em></div>
<div class="tip" id="fs48">SuaveConfig.cancellationToken: obj<br /><em><br /><br />&#160;A cancellation token for the web server. Signalling this token<br />&#160;means that the web server shuts down</em></div>
<div class="tip" id="fs49">SuaveConfig.bufferSize: int<br /><em><br /><br />&#160;buffer size for socket operations</em></div>
<div class="tip" id="fs50">Multiple items<br />val int : value:&#39;T -&gt; int (requires member op_Explicit)<br /><br />Full name: Microsoft.FSharp.Core.Operators.int<br /><br />--------------------<br />type int = int32<br /><br />Full name: Microsoft.FSharp.Core.int<br /><br />--------------------<br />type int&lt;&#39;Measure&gt; = int<br /><br />Full name: Microsoft.FSharp.Core.int&lt;_&gt;</div>
<div class="tip" id="fs51">SuaveConfig.autoGrow: bool<br /><em><br /><br />&#160;Buffer manager auto grow</em></div>
<div class="tip" id="fs52">SuaveConfig.maxOps: int<br /><em><br /><br />&#160;max number of concurrent socket operations</em></div>
<div class="tip" id="fs53">SuaveConfig.mimeTypesMap: MimeTypesMap<br /><em><br /><br />&#160;MIME types</em></div>
<div class="tip" id="fs54">SuaveConfig.homeFolder: string option<br /><em><br /><br />&#160;Home or root directory</em></div>
<div class="tip" id="fs55">type &#39;T option = Option&lt;&#39;T&gt;<br /><br />Full name: Microsoft.FSharp.Core.option&lt;_&gt;</div>
<div class="tip" id="fs56">SuaveConfig.compressedFilesFolder: string option<br /><em><br /><br />&#160;Folder for temporary compressed files</em></div>
<div class="tip" id="fs57">SuaveConfig.logger: Logger<br /><em><br /><br />&#160;Suave&#39;s logger. You can override the default instance if you wish to<br />&#160;ship your logs, e.g. using https://www.nuget.org/packages/Logary.Adapters.Suave/<br />&#160;Also, this logger will be configured by default for Suave unless you<br />&#160;explicitly use `Suave.Logging.Global.initialise` before starting the<br />&#160;web server (the first time – the second time, the static will already<br />&#160;have been initialised).</em></div>
<div class="tip" id="fs58">SuaveConfig.tcpServerFactory: TcpServerFactory<br /><em><br /><br />&#160;Pluggable TCP async sockets implementation. You can choose betwee libuv<br />&#160;and CLR&#39;s Async Socket Event Args. Currently defaults to the managed-only<br />&#160;implementation.</em></div>
<div class="tip" id="fs59">type TcpServerFactory =<br />&#160;&#160;interface<br />&#160;&#160;&#160;&#160;abstract member create : maxOps:int * bufferSize:int * autoGrow:bool * binding:SocketBinding -&gt; TcpServer<br />&#160;&#160;end<br /><br />Full name: Suave.TcpServerFactory</div>
<div class="tip" id="fs60">SuaveConfig.cookieSerialiser: CookieSerialiser<br /><em><br /><br />&#160;The cookie serialiser to use for converting the data you save in cookies<br />&#160;from your application into a byte array.</em></div>
<div class="tip" id="fs61">type CookieSerialiser =<br />&#160;&#160;interface<br />&#160;&#160;&#160;&#160;abstract member deserialise : byte [] -&gt; Map&lt;string,obj&gt;<br />&#160;&#160;&#160;&#160;abstract member serialise : Map&lt;string,obj&gt; -&gt; byte []<br />&#160;&#160;end<br /><br />Full name: Suave.CookieSerialiser</div>
<div class="tip" id="fs62">SuaveConfig.tlsProvider: TlsProvider<br /><em><br /><br />&#160;A TLS provider implementation.</em></div>
<div class="tip" id="fs63">type TlsProvider =<br />&#160;&#160;interface<br />&#160;&#160;&#160;&#160;abstract member wrap : Connection * obj -&gt; SocketOp&lt;Connection&gt;<br />&#160;&#160;end<br /><br />Full name: Suave.Http.TlsProvider</div>
<div class="tip" id="fs64">SuaveConfig.hideHeader: bool<br /><em><br /><br />&#160;Make this true, if you want Suave not to display its server header in<br />&#160;every response. Defaults to false.</em></div>
<div class="tip" id="fs65">SuaveConfig.maxContentLength: int<br /><em><br /><br />&#160;Maximun upload size in bytes</em></div>
<div class="tip" id="fs66">type ITlsProvider =<br />&#160;&#160;interface<br />&#160;&#160;&#160;&#160;abstract member Wrap : &#39;a0 -&gt; &#39;a1<br />&#160;&#160;end<br /><br />Full name: temp.ITlsProvider</div>
<div class="tip" id="fs67">abstract member ITlsProvider.Wrap : &#39;a0 -&gt; &#39;a1<br /><br />Full name: temp.ITlsProvider.Wrap</div>
<div class="tip" id="fs68">type Protocol =<br />&#160;&#160;| HTTP<br />&#160;&#160;| HTTPS of ITlsProvider<br /><br />Full name: temp.Protocol<br /><em><br /><br />&#160;Gets the supported protocols, HTTP and HTTPS with a certificate</em></div>
<div class="tip" id="fs69">union case Protocol.HTTP: Protocol<br /><em><br /><br />&#160;The HTTP protocol is the core protocol</em></div>
<div class="tip" id="fs70">union case Protocol.HTTPS: ITlsProvider -&gt; Protocol<br /><em><br /><br />&#160;The HTTP protocol tunneled in a TLS tunnel</em></div>
<div class="tip" id="fs71">Multiple items<br />module HttpBinding<br /><br />from Suave.Http<br /><br />--------------------<br />type HttpBinding =<br />&#160;&#160;{scheme: Protocol;<br />&#160;&#160;&#160;ip: obj;<br />&#160;&#160;&#160;port: uint16;}<br /><br />Full name: temp.HttpBinding<br /><em><br /><br />&#160;A HTTP binding is a protocol is the product of HTTP or HTTP, a DNS or IP binding<br />&#160;and a port number</em></div>
<div class="tip" id="fs72">HttpBinding.scheme: Protocol<br /><em><br /><br />&#160;The scheme in use</em></div>
<div class="tip" id="fs73">HttpBinding.ip: obj<br /><em><br /><br />&#160;The host or IP address to bind to. This will be interpreted by the operating system</em></div>
<div class="tip" id="fs74">HttpBinding.port: uint16<br /><em><br /><br />&#160;The port for the binding</em></div>
<div class="tip" id="fs75">Multiple items<br />val uint16 : value:&#39;T -&gt; uint16 (requires member op_Explicit)<br /><br />Full name: Microsoft.FSharp.Core.Operators.uint16<br /><br />--------------------<br />type uint16 = System.UInt16<br /><br />Full name: Microsoft.FSharp.Core.uint16</div>
<div class="tip" id="fs76">type MimeType =<br />&#160;&#160;{name: string;<br />&#160;&#160;&#160;compression: bool;}<br /><br />Full name: temp.MimeType</div>
<div class="tip" id="fs77">MimeType.name: string<br /><em><br /><br />&#160;The name of the mime type, i.e &quot;text/plain&quot;</em></div>
<div class="tip" id="fs78">MimeType.compression: bool<br /><em><br /><br />&#160;If the server will compress the file when clients ask for gzip or<br />&#160;deflate in the `Accept-Encoding` header</em></div>
<div class="tip" id="fs79">type SuaveTask&lt;&#39;a&gt; = Async&lt;&#39;a option&gt;<br /><br />Full name: temp.SuaveTask&lt;_&gt;</div>
<div class="tip" id="fs80">Multiple items<br />module Async<br /><br />from YoLo<br /><br />--------------------<br />type Async<br />static member AsBeginEnd : computation:(&#39;Arg -&gt; Async&lt;&#39;T&gt;) -&gt; (&#39;Arg * AsyncCallback * obj -&gt; IAsyncResult) * (IAsyncResult -&gt; &#39;T) * (IAsyncResult -&gt; unit)<br />static member AwaitEvent : event:IEvent&lt;&#39;Del,&#39;T&gt; * ?cancelAction:(unit -&gt; unit) -&gt; Async&lt;&#39;T&gt; (requires delegate and &#39;Del :&gt; Delegate)<br />static member AwaitIAsyncResult : iar:IAsyncResult * ?millisecondsTimeout:int -&gt; Async&lt;bool&gt;<br />static member AwaitTask : task:Task -&gt; Async&lt;unit&gt;<br />static member AwaitTask : task:Task&lt;&#39;T&gt; -&gt; Async&lt;&#39;T&gt;<br />static member AwaitWaitHandle : waitHandle:WaitHandle * ?millisecondsTimeout:int -&gt; Async&lt;bool&gt;<br />static member CancelDefaultToken : unit -&gt; unit<br />static member Catch : computation:Async&lt;&#39;T&gt; -&gt; Async&lt;Choice&lt;&#39;T,exn&gt;&gt;<br />static member Choice : computations:seq&lt;Async&lt;&#39;T option&gt;&gt; -&gt; Async&lt;&#39;T option&gt;<br />static member FromBeginEnd : beginAction:(AsyncCallback * obj -&gt; IAsyncResult) * endAction:(IAsyncResult -&gt; &#39;T) * ?cancelAction:(unit -&gt; unit) -&gt; Async&lt;&#39;T&gt;<br />static member FromBeginEnd : arg:&#39;Arg1 * beginAction:(&#39;Arg1 * AsyncCallback * obj -&gt; IAsyncResult) * endAction:(IAsyncResult -&gt; &#39;T) * ?cancelAction:(unit -&gt; unit) -&gt; Async&lt;&#39;T&gt;<br />static member FromBeginEnd : arg1:&#39;Arg1 * arg2:&#39;Arg2 * beginAction:(&#39;Arg1 * &#39;Arg2 * AsyncCallback * obj -&gt; IAsyncResult) * endAction:(IAsyncResult -&gt; &#39;T) * ?cancelAction:(unit -&gt; unit) -&gt; Async&lt;&#39;T&gt;<br />static member FromBeginEnd : arg1:&#39;Arg1 * arg2:&#39;Arg2 * arg3:&#39;Arg3 * beginAction:(&#39;Arg1 * &#39;Arg2 * &#39;Arg3 * AsyncCallback * obj -&gt; IAsyncResult) * endAction:(IAsyncResult -&gt; &#39;T) * ?cancelAction:(unit -&gt; unit) -&gt; Async&lt;&#39;T&gt;<br />static member FromContinuations : callback:((&#39;T -&gt; unit) * (exn -&gt; unit) * (OperationCanceledException -&gt; unit) -&gt; unit) -&gt; Async&lt;&#39;T&gt;<br />static member Ignore : computation:Async&lt;&#39;T&gt; -&gt; Async&lt;unit&gt;<br />static member OnCancel : interruption:(unit -&gt; unit) -&gt; Async&lt;IDisposable&gt;<br />static member Parallel : computations:seq&lt;Async&lt;&#39;T&gt;&gt; -&gt; Async&lt;&#39;T []&gt;<br />static member RunSynchronously : computation:Async&lt;&#39;T&gt; * ?timeout:int * ?cancellationToken:CancellationToken -&gt; &#39;T<br />static member Sleep : millisecondsDueTime:int -&gt; Async&lt;unit&gt;<br />static member Start : computation:Async&lt;unit&gt; * ?cancellationToken:CancellationToken -&gt; unit<br />static member StartAsTask : computation:Async&lt;&#39;T&gt; * ?taskCreationOptions:TaskCreationOptions * ?cancellationToken:CancellationToken -&gt; Task&lt;&#39;T&gt;<br />static member StartChild : computation:Async&lt;&#39;T&gt; * ?millisecondsTimeout:int -&gt; Async&lt;Async&lt;&#39;T&gt;&gt;<br />static member StartChildAsTask : computation:Async&lt;&#39;T&gt; * ?taskCreationOptions:TaskCreationOptions -&gt; Async&lt;Task&lt;&#39;T&gt;&gt;<br />static member StartImmediate : computation:Async&lt;unit&gt; * ?cancellationToken:CancellationToken -&gt; unit<br />static member StartWithContinuations : computation:Async&lt;&#39;T&gt; * continuation:(&#39;T -&gt; unit) * exceptionContinuation:(exn -&gt; unit) * cancellationContinuation:(OperationCanceledException -&gt; unit) * ?cancellationToken:CancellationToken -&gt; unit<br />static member SwitchToContext : syncContext:SynchronizationContext -&gt; Async&lt;unit&gt;<br />static member SwitchToNewThread : unit -&gt; Async&lt;unit&gt;<br />static member SwitchToThreadPool : unit -&gt; Async&lt;unit&gt;<br />static member TryCancelled : computation:Async&lt;&#39;T&gt; * compensation:(OperationCanceledException -&gt; unit) -&gt; Async&lt;&#39;T&gt;<br />static member CancellationToken : Async&lt;CancellationToken&gt;<br />static member DefaultCancellationToken : CancellationToken<br /><br />Full name: Microsoft.FSharp.Control.Async<br /><br />--------------------<br />type Async&lt;&#39;T&gt;<br /><br />Full name: Microsoft.FSharp.Control.Async&lt;_&gt;</div>
<div class="tip" id="fs81">Multiple items<br />module WebPart<br /><br />from Suave<br /><br />--------------------<br />type WebPart = HttpContext -&gt; SuaveTask&lt;HttpContext&gt;<br /><br />Full name: temp.WebPart<br /><br />--------------------<br />type WebPart&lt;&#39;a&gt; = &#39;a -&gt; Async&lt;&#39;a option&gt;<br /><br />Full name: Suave.WebPart.WebPart&lt;_&gt;</div>
<div class="tip" id="fs82">val myCfg : SuaveConfig<br /><br />Full name: temp.myCfg</div>
<div class="tip" id="fs83">val defaultConfig : SuaveConfig<br /><br />Full name: Suave.Web.defaultConfig</div>
<div class="tip" id="fs84">val createSimple : scheme:Protocol -&gt; ip:string -&gt; port:int -&gt; HttpBinding<br /><br />Full name: Suave.Http.HttpBinding.createSimple</div>
<div class="tip" id="fs85">val myMimeTypesMap : ext:string -&gt; MimeType<br /><br />Full name: temp.myMimeTypesMap</div>
<div class="tip" id="fs86">val ext : string</div>
<div class="tip" id="fs87">module Writers<br /><br />from Suave</div>
<div class="tip" id="fs88">val defaultMimeTypesMap : ext:string -&gt; MimeType option<br /><br />Full name: Suave.Writers.defaultMimeTypesMap</div>
<div class="tip" id="fs89">union case Option.Some: Value: &#39;T -&gt; Option&lt;&#39;T&gt;</div>
<div class="tip" id="fs90">val mime : MimeType</div>
<div class="tip" id="fs91">union case Option.None: Option&lt;&#39;T&gt;</div>
<div class="tip" id="fs92">namespace Suave</div>
