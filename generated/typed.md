<h1>Typed routes</h1>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">let</span> <span onmouseout="hideTip(event, 'fs1', 1)" onmouseover="showTip(event, 'fs1', 1)" class="f">testapp</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs2', 2)" onmouseover="showTip(event, 'fs2', 2)" class="t">WebPart</span> <span class="o">=</span>
  <span onmouseout="hideTip(event, 'fs3', 3)" onmouseover="showTip(event, 'fs3', 3)" class="f">choose</span>
    [ <span onmouseout="hideTip(event, 'fs4', 4)" onmouseover="showTip(event, 'fs4', 4)" class="f">pathScan</span> <span class="s">&quot;/add/</span><span class="pf">%d</span><span class="s">/</span><span class="pf">%d</span><span class="s">&quot;</span> (<span class="k">fun</span> (<span onmouseout="hideTip(event, 'fs5', 5)" onmouseover="showTip(event, 'fs5', 5)" class="i">a</span>,<span onmouseout="hideTip(event, 'fs6', 6)" onmouseover="showTip(event, 'fs6', 6)" class="i">b</span>) <span class="k">-&gt;</span> <span onmouseout="hideTip(event, 'fs7', 7)" onmouseover="showTip(event, 'fs7', 7)" class="f">OK</span>((<span onmouseout="hideTip(event, 'fs5', 8)" onmouseover="showTip(event, 'fs5', 8)" class="i">a</span> <span class="o">+</span> <span onmouseout="hideTip(event, 'fs6', 9)" onmouseover="showTip(event, 'fs6', 9)" class="i">b</span>)<span class="o">.</span><span class="f">ToString</span>()))
      <span onmouseout="hideTip(event, 'fs8', 10)" onmouseover="showTip(event, 'fs8', 10)" class="f">NOT_FOUND</span> <span class="s">&quot;Found no handlers&quot;</span> ]
</div></pre>



<div class="tip" id="fs1">val testapp : WebPart<br /><br />Full name: temp.testapp</div>
<div class="tip" id="fs2">Multiple items<br />module WebPart<br /><br />from Suave<br /><br />--------------------<br />type WebPart = WebPart&lt;HttpContext&gt;<br /><br />Full name: Suave.Http.WebPart<br /><br />--------------------<br />type WebPart&lt;&#39;a&gt; = &#39;a -&gt; Async&lt;&#39;a option&gt;<br /><br />Full name: Suave.WebPart.WebPart&lt;_&gt;</div>
<div class="tip" id="fs3">val choose : options:WebPart&lt;&#39;a&gt; list -&gt; WebPart&lt;&#39;a&gt;<br /><br />Full name: Suave.WebPart.choose</div>
<div class="tip" id="fs4">val pathScan : pf:PrintfFormat&lt;&#39;a,&#39;b,&#39;c,&#39;d,&#39;t&gt; -&gt; h:(&#39;t -&gt; WebPart) -&gt; WebPart<br /><br />Full name: Suave.Filters.pathScan</div>
<div class="tip" id="fs5">val a : int</div>
<div class="tip" id="fs6">val b : int</div>
<div class="tip" id="fs7">val OK : body:string -&gt; WebPart<br /><br />Full name: Suave.Successful.OK</div>
<div class="tip" id="fs8">val NOT_FOUND : body:string -&gt; WebPart<br /><br />Full name: Suave.RequestErrors.NOT_FOUND</div>
