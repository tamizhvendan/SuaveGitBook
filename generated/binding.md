<h1>Multiple bindings and SSL support</h1>
<p>Suave supports binding the application to multiple TCP/IP addresses and ports
combinations. It also supports HTTPS via the interface <code>ITlsProvider</code>, but the current
recommendation for deploying HTTPS is by letting a reverse proxy manage the HTTPS
termination.</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">let</span> <span onmouseout="hideTip(event, 'fs1', 1)" onmouseover="showTip(event, 'fs1', 1)" class="i">cfg</span> <span class="o">=</span>
  { <span onmouseout="hideTip(event, 'fs2', 2)" onmouseover="showTip(event, 'fs2', 2)" class="i">defaultConfig</span> <span class="k">with</span>
      <span class="i">bindings</span> <span class="o">=</span>
        [ <span onmouseout="hideTip(event, 'fs3', 3)" onmouseover="showTip(event, 'fs3', 3)" class="t">HttpBinding</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs4', 4)" onmouseover="showTip(event, 'fs4', 4)" class="f">create</span> <span onmouseout="hideTip(event, 'fs5', 5)" onmouseover="showTip(event, 'fs5', 5)" class="p">HTTP</span> <span class="i">IPAddress</span><span class="o">.</span><span class="i">Loopback</span> <span class="n">80us</span>
          <span onmouseout="hideTip(event, 'fs3', 6)" onmouseover="showTip(event, 'fs3', 6)" class="t">HttpBinding</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs6', 7)" onmouseover="showTip(event, 'fs6', 7)" class="f">createSimple</span> <span onmouseout="hideTip(event, 'fs5', 8)" onmouseover="showTip(event, 'fs5', 8)" class="p">HTTP</span> <span class="s">&quot;10.0.1.34&quot;</span> <span class="n">9000</span> ]
      <span class="i">listenTimeout</span> <span class="o">=</span> <span class="i">TimeSpan</span><span class="o">.</span><span class="i">FromMilliseconds</span> <span class="n">3000.</span> }
<span onmouseout="hideTip(event, 'fs7', 9)" onmouseover="showTip(event, 'fs7', 9)" class="f">choose</span> [
  <span onmouseout="hideTip(event, 'fs8', 10)" onmouseover="showTip(event, 'fs8', 10)" class="f">path</span> <span class="s">&quot;/hello&quot;</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs9', 11)" onmouseover="showTip(event, 'fs9', 11)" class="f">OK</span> <span class="s">&quot;Hello World&quot;</span>
  <span onmouseout="hideTip(event, 'fs10', 12)" onmouseover="showTip(event, 'fs10', 12)" class="f">NOT_FOUND</span> <span class="s">&quot;Found no handlers&quot;</span>
]
<span class="o">|&gt;</span> <span onmouseout="hideTip(event, 'fs11', 13)" onmouseover="showTip(event, 'fs11', 13)" class="f">startWebServer</span> <span onmouseout="hideTip(event, 'fs1', 14)" onmouseover="showTip(event, 'fs1', 14)" class="i">cfg</span>
</div></pre>



<div class="tip" id="fs1">val cfg : SuaveConfig<br /><br />Full name: temp.cfg</div>
<div class="tip" id="fs2">val defaultConfig : SuaveConfig<br /><br />Full name: Suave.Web.defaultConfig</div>
<div class="tip" id="fs3">Multiple items<br />module HttpBinding<br /><br />from Suave.Http<br /><br />--------------------<br />type HttpBinding =<br />&#160;&#160;{scheme: Protocol;<br />&#160;&#160;&#160;socketBinding: SocketBinding;}<br />&#160;&#160;override ToString : unit -&gt; string<br />&#160;&#160;member uri : path:string -&gt; query:string -&gt; Uri<br />&#160;&#160;static member scheme_ : Property&lt;HttpBinding,Protocol&gt;<br />&#160;&#160;static member socketBinding_ : Property&lt;HttpBinding,SocketBinding&gt;<br /><br />Full name: Suave.Http.HttpBinding</div>
<div class="tip" id="fs4">val create : scheme:Protocol -&gt; ip:System.Net.IPAddress -&gt; port:Sockets.Port -&gt; HttpBinding<br /><br />Full name: Suave.Http.HttpBinding.create</div>
<div class="tip" id="fs5">union case Protocol.HTTP: Protocol</div>
<div class="tip" id="fs6">val createSimple : scheme:Protocol -&gt; ip:string -&gt; port:int -&gt; HttpBinding<br /><br />Full name: Suave.Http.HttpBinding.createSimple</div>
<div class="tip" id="fs7">val choose : options:WebPart&lt;&#39;a&gt; list -&gt; WebPart&lt;&#39;a&gt;<br /><br />Full name: Suave.WebPart.choose</div>
<div class="tip" id="fs8">val path : pathAfterDomain:string -&gt; WebPart<br /><br />Full name: Suave.Filters.path</div>
<div class="tip" id="fs9">val OK : body:string -&gt; WebPart<br /><br />Full name: Suave.Successful.OK</div>
<div class="tip" id="fs10">val NOT_FOUND : body:string -&gt; WebPart<br /><br />Full name: Suave.RequestErrors.NOT_FOUND</div>
<div class="tip" id="fs11">val startWebServer : config:SuaveConfig -&gt; webpart:WebPart -&gt; unit<br /><br />Full name: Suave.Web.startWebServer</div>
