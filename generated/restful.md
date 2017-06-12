<h1>Building RESTful Web Services</h1>
<p>We can expose simple REST web services with the help of the combinator <code>mapJson</code>. The <code>mapJson</code> uses the default BCL JSON serializer <code>DataContractJsonSerializer</code>.</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">open</span> <span onmouseout="hideTip(event, 'fs1', 1)" onmouseover="showTip(event, 'fs1', 1)" class="i">Suave</span>
<span class="k">open</span> <span onmouseout="hideTip(event, 'fs1', 2)" onmouseover="showTip(event, 'fs1', 2)" class="i">Suave</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs2', 3)" onmouseover="showTip(event, 'fs2', 3)" class="i">Json</span>
<span class="k">open</span> <span onmouseout="hideTip(event, 'fs3', 4)" onmouseover="showTip(event, 'fs3', 4)" class="i">System</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs4', 5)" onmouseover="showTip(event, 'fs4', 5)" class="i">Runtime</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs5', 6)" onmouseover="showTip(event, 'fs5', 6)" class="i">Serialization</span>

[&lt;<span class="i">DataContract</span>&gt;]
<span class="k">type</span> <span onmouseout="hideTip(event, 'fs6', 7)" onmouseover="showTip(event, 'fs6', 7)" class="t">Foo</span> <span class="o">=</span>
  { [&lt;<span class="i">field</span><span class="o">:</span> <span class="i">DataMember</span>(<span class="i">Name</span> <span class="o">=</span> <span class="s">&quot;foo&quot;</span>)&gt;]
    <span onmouseout="hideTip(event, 'fs7', 8)" onmouseover="showTip(event, 'fs7', 8)" class="i">foo</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs8', 9)" onmouseover="showTip(event, 'fs8', 9)" class="t">string</span> }

[&lt;<span class="i">DataContract</span>&gt;]
<span class="k">type</span> <span onmouseout="hideTip(event, 'fs9', 10)" onmouseover="showTip(event, 'fs9', 10)" class="t">Bar</span> <span class="o">=</span>
  { [&lt;<span class="i">field</span><span class="o">:</span> <span class="i">DataMember</span>(<span class="i">Name</span> <span class="o">=</span> <span class="s">&quot;bar&quot;</span>)&gt;]
    <span onmouseout="hideTip(event, 'fs10', 11)" onmouseover="showTip(event, 'fs10', 11)" class="i">bar</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs8', 12)" onmouseover="showTip(event, 'fs8', 12)" class="t">string</span> }

<span onmouseout="hideTip(event, 'fs11', 13)" onmouseover="showTip(event, 'fs11', 13)" class="f">startWebServer</span> <span onmouseout="hideTip(event, 'fs12', 14)" onmouseover="showTip(event, 'fs12', 14)" class="i">defaultConfig</span> (<span onmouseout="hideTip(event, 'fs13', 15)" onmouseover="showTip(event, 'fs13', 15)" class="f">mapJson</span> (<span class="k">fun</span> (<span onmouseout="hideTip(event, 'fs14', 16)" onmouseover="showTip(event, 'fs14', 16)" class="i">a</span><span class="o">:</span><span onmouseout="hideTip(event, 'fs6', 17)" onmouseover="showTip(event, 'fs6', 17)" class="t">Foo</span>) <span class="k">-&gt;</span> { <span class="i">bar</span> <span class="o">=</span> <span onmouseout="hideTip(event, 'fs14', 18)" onmouseover="showTip(event, 'fs14', 18)" class="i">a</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs7', 19)" onmouseover="showTip(event, 'fs7', 19)" class="i">foo</span> }))
</div></pre>

<br/>
<table class="pre"><tr><td class="snippet"><pre class="fssnip"><div lang="bash">ademar@nascio:~$ curl -X POST -d '{"foo":"xyz"}' http://localhost:8083/ -w "\n"
{"bar":"xyz"}
</div></pre>
</td></tr></table>
<p>Or you can bring your own JSON serializer like Chiron:<a href="https://github.com/xyncro/chiron">https://github.com/xyncro/chiron</a></p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">type</span> <span onmouseout="hideTip(event, 'fs15', 20)" onmouseover="showTip(event, 'fs15', 20)" class="t">A</span> <span class="o">=</span> 
  { <span onmouseout="hideTip(event, 'fs16', 21)" onmouseover="showTip(event, 'fs16', 21)" class="i">a</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs17', 22)" onmouseover="showTip(event, 'fs17', 22)" class="t">int</span> }
  <span class="k">static</span> <span class="k">member</span> <span onmouseout="hideTip(event, 'fs18', 23)" onmouseover="showTip(event, 'fs18', 23)" class="f">ToJson</span> (<span onmouseout="hideTip(event, 'fs19', 24)" onmouseover="showTip(event, 'fs19', 24)" class="i">x</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs15', 25)" onmouseover="showTip(event, 'fs15', 25)" class="t">A</span>) <span class="o">=</span>
    <span onmouseout="hideTip(event, 'fs2', 26)" onmouseover="showTip(event, 'fs2', 26)" class="i">Json</span><span class="o">.</span><span class="i">writer</span> <span class="s">&quot;a&quot;</span> <span onmouseout="hideTip(event, 'fs19', 27)" onmouseover="showTip(event, 'fs19', 27)" class="i">x</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs16', 28)" onmouseover="showTip(event, 'fs16', 28)" class="i">a</span>
</div></pre>

<br/>
<table class="pre"><tr><td class="snippet"><pre class="fssnip"><div lang="bash">Json.format (Json.serialize { a = 42 })
val it = """{"a":42}"""
</div></pre>
</td></tr></table>
<br/>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">let</span> <span onmouseout="hideTip(event, 'fs20', 29)" onmouseover="showTip(event, 'fs20', 29)" class="f">app</span> <span class="o">=</span>
  <span onmouseout="hideTip(event, 'fs21', 30)" onmouseover="showTip(event, 'fs21', 30)" class="p">GET</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs22', 31)" onmouseover="showTip(event, 'fs22', 31)" class="f">path</span> <span class="s">&quot;/test&quot;</span>
  <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs23', 32)" onmouseover="showTip(event, 'fs23', 32)" class="f">OK</span> (<span onmouseout="hideTip(event, 'fs24', 33)" onmouseover="showTip(event, 'fs24', 33)" class="t">UTF8</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs25', 34)" onmouseover="showTip(event, 'fs25', 34)" class="f">bytes</span> <span class="i">it</span>)
  <span class="o">&gt;</span><span class="o">=&gt;</span> <span class="i">setMimeType</span> <span class="s">&quot;application/json; charset=utf-8&quot;</span>
</div></pre>



<div class="tip" id="fs1">namespace Suave</div>
<div class="tip" id="fs2">module Json<br /><br />from Suave</div>
<div class="tip" id="fs3">namespace System</div>
<div class="tip" id="fs4">namespace System.Runtime</div>
<div class="tip" id="fs5">namespace System.Runtime.Serialization</div>
<div class="tip" id="fs6">type Foo =<br />&#160;&#160;{foo: string;}<br /><br />Full name: temp.Foo</div>
<div class="tip" id="fs7">Foo.foo: string</div>
<div class="tip" id="fs8">Multiple items<br />val string : value:&#39;T -&gt; string<br /><br />Full name: Microsoft.FSharp.Core.Operators.string<br /><br />--------------------<br />type string = System.String<br /><br />Full name: Microsoft.FSharp.Core.string</div>
<div class="tip" id="fs9">type Bar =<br />&#160;&#160;{bar: string;}<br /><br />Full name: temp.Bar</div>
<div class="tip" id="fs10">Bar.bar: string</div>
<div class="tip" id="fs11">val startWebServer : config:SuaveConfig -&gt; webpart:WebPart -&gt; unit<br /><br />Full name: Suave.Web.startWebServer</div>
<div class="tip" id="fs12">val defaultConfig : SuaveConfig<br /><br />Full name: Suave.Web.defaultConfig</div>
<div class="tip" id="fs13">val mapJson&lt;&#39;T1,&#39;T2&gt; : ((&#39;T1 -&gt; &#39;T2) -&gt; HttpContext -&gt; Async&lt;HttpContext option&gt;)<br /><br />Full name: Suave.Json.mapJson</div>
<div class="tip" id="fs14">val a : Foo</div>
<div class="tip" id="fs15">type A =<br />&#160;&#160;{a: int;}<br />&#160;&#160;static member ToJson : x:A -&gt; &#39;a<br /><br />Full name: temp.A</div>
<div class="tip" id="fs16">A.a: int</div>
<div class="tip" id="fs17">Multiple items<br />val int : value:&#39;T -&gt; int (requires member op_Explicit)<br /><br />Full name: Microsoft.FSharp.Core.Operators.int<br /><br />--------------------<br />type int = int32<br /><br />Full name: Microsoft.FSharp.Core.int<br /><br />--------------------<br />type int&lt;&#39;Measure&gt; = int<br /><br />Full name: Microsoft.FSharp.Core.int&lt;_&gt;</div>
<div class="tip" id="fs18">static member A.ToJson : x:A -&gt; &#39;a<br /><br />Full name: temp.A.ToJson</div>
<div class="tip" id="fs19">val x : A</div>
<div class="tip" id="fs20">val app : (obj -&gt; Async&lt;obj option&gt;)<br /><br />Full name: temp.app</div>
<div class="tip" id="fs21">union case HttpMethod.GET: HttpMethod</div>
<div class="tip" id="fs22">val path : pathAfterDomain:string -&gt; WebPart<br /><br />Full name: Suave.Filters.path</div>
<div class="tip" id="fs23">val OK : body:string -&gt; WebPart<br /><br />Full name: Suave.Successful.OK</div>
<div class="tip" id="fs24">module UTF8<br /><br />from YoLo</div>
<div class="tip" id="fs25">val bytes : s:string -&gt; byte []<br /><br />Full name: YoLo.UTF8.bytes</div>
