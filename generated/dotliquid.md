<h1>Suave.DotLiquid</h1>
<h2>Installing DotLiquid</h2>
<table class="pre"><tr><td class="snippet"><pre class="fssnip"><div lang="bash">paket add nuget DotLiquid
paket add nuget Suave.DotLiquid
</div></pre>
</td></tr></table>
<h2>How to use liquid from Suave.</h2>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">open</span> <span onmouseout="hideTip(event, 'fs1', 1)" onmouseover="showTip(event, 'fs1', 1)" class="i">Suave</span>
<span class="k">open</span> <span onmouseout="hideTip(event, 'fs1', 2)" onmouseover="showTip(event, 'fs1', 2)" class="i">Suave</span><span class="o">.</span><span class="i">DotLiquid</span>
<span class="k">open</span> <span class="i">DotLiquid</span>

<span class="k">type</span> <span onmouseout="hideTip(event, 'fs2', 3)" onmouseover="showTip(event, 'fs2', 3)" class="t">Model</span> <span class="o">=</span>
  { <span onmouseout="hideTip(event, 'fs3', 4)" onmouseover="showTip(event, 'fs3', 4)" class="i">title</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs4', 5)" onmouseover="showTip(event, 'fs4', 5)" class="t">string</span> }

<span class="i">setTemplatesDirectory</span> <span class="s">&quot;./templates&quot;</span>

<span class="k">let</span> <span onmouseout="hideTip(event, 'fs5', 6)" onmouseover="showTip(event, 'fs5', 6)" class="i">o</span> <span class="o">=</span> { <span class="i">title</span> <span class="o">=</span> <span class="s">&quot;Hello World&quot;</span> }

<span class="k">let</span> <span onmouseout="hideTip(event, 'fs6', 7)" onmouseover="showTip(event, 'fs6', 7)" class="f">app</span> <span class="o">=</span>
  <span onmouseout="hideTip(event, 'fs7', 8)" onmouseover="showTip(event, 'fs7', 8)" class="f">choose</span>
    [ <span onmouseout="hideTip(event, 'fs8', 9)" onmouseover="showTip(event, 'fs8', 9)" class="p">GET</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span onmouseout="hideTip(event, 'fs7', 10)" onmouseover="showTip(event, 'fs7', 10)" class="f">choose</span>
        [ <span onmouseout="hideTip(event, 'fs9', 11)" onmouseover="showTip(event, 'fs9', 11)" class="f">path</span> <span class="s">&quot;/&quot;</span> <span class="o">&gt;</span><span class="o">=&gt;</span> <span class="i">page</span> <span class="s">&quot;my_page.liquid&quot;</span> <span onmouseout="hideTip(event, 'fs5', 12)" onmouseover="showTip(event, 'fs5', 12)" class="i">o</span> ]]
</div></pre>

<p>Then, for your template:</p>
<table class="pre"><tr><td class="snippet"><pre class="fssnip highlighted"><div lang="html"><span class="k">&lt;</span><span class="i">html</span><span class="k">&gt;</span>
  <span class="k">&lt;</span><span class="i">head</span><span class="k">&gt;</span>
    <span class="k">&lt;</span><span class="i">title</span><span class="k">&gt;</span>{{ model.title }}<span class="k">&lt;/</span><span class="i">title</span><span class="k">&gt;</span>
  <span class="k">&lt;/</span><span class="i">head</span><span class="k">&gt;</span>
  <span class="k">&lt;</span><span class="i">body</span><span class="k">&gt;</span>
    <span class="k">&lt;</span><span class="i">p</span><span class="k">&gt;</span>Hello from {{ model.title }}!<span class="k">&lt;/</span><span class="i">p</span><span class="k">&gt;</span>
  <span class="k">&lt;/</span><span class="i">body</span><span class="k">&gt;</span>
<span class="k">&lt;/</span><span class="i">html</span><span class="k">&gt;</span>
</div></pre>
</td></tr></table>
<h2>Naming conventions</h2>
<p>Suave.DotLiquid sets the DotLiquid naming convention to Ruby by default. This means that if, for example, your model is a record type with a member called 'Name', DotLiquid would expect the binding to be '{% raw %}{{model.name}}{% endraw %}'. You can change the naming convention to C#:</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="i">DotLiquid</span><span class="o">.</span><span class="i">setCSharpNamingConvention</span>()
</div></pre>

<h2>Working with Options</h2>
<p>DotLiquid can handle option types.</p>
<p>Example 1:</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">type</span> <span onmouseout="hideTip(event, 'fs10', 13)" onmouseover="showTip(event, 'fs10', 13)" class="t">UserModel</span> <span class="o">=</span> {
    <span onmouseout="hideTip(event, 'fs11', 14)" onmouseover="showTip(event, 'fs11', 14)" class="i">UserName</span><span class="o">:</span> <span onmouseout="hideTip(event, 'fs4', 15)" onmouseover="showTip(event, 'fs4', 15)" class="t">string</span> <span onmouseout="hideTip(event, 'fs12', 16)" onmouseover="showTip(event, 'fs12', 16)" class="t">option</span>
}

<span class="k">let</span> <span onmouseout="hideTip(event, 'fs13', 17)" onmouseover="showTip(event, 'fs13', 17)" class="i">model</span> <span class="o">=</span> { <span class="i">UserName</span> <span class="o">=</span> <span onmouseout="hideTip(event, 'fs14', 18)" onmouseover="showTip(event, 'fs14', 18)" class="p">Some</span> <span class="s">&quot;Dave&quot;</span> }
<span class="c">// or</span>
<span class="k">let</span> <span onmouseout="hideTip(event, 'fs13', 19)" onmouseover="showTip(event, 'fs13', 19)" class="i">model</span> <span class="o">=</span> { <span class="i">UserName</span> <span class="o">=</span> <span onmouseout="hideTip(event, 'fs15', 20)" onmouseover="showTip(event, 'fs15', 20)" class="p">None</span> }

<span class="k">let</span> <span onmouseout="hideTip(event, 'fs16', 21)" onmouseover="showTip(event, 'fs16', 21)" class="i">home</span> <span class="o">=</span> <span class="i">page</span> <span class="s">&quot;Index.html&quot;</span> <span onmouseout="hideTip(event, 'fs13', 22)" onmouseover="showTip(event, 'fs13', 22)" class="i">model</span>
</div></pre>

<br />
<table class="pre"><tr><td class="snippet"><pre class="fssnip highlighted"><div lang="csharp">&lt;div&gt;
    {<span class="o">%</span> <span class="k">if</span> model.UserName <span class="o">%</span>}
        Hello {{model.UserName.Value}}
    {<span class="o">%</span> <span class="k">else</span> <span class="o">%</span>}
        Dave <span class="k">is</span> not here
    {<span class="o">%</span> endif <span class="o">%</span>}
<span class="o">&lt;</span>/div&gt;
</div></pre>
</td></tr></table>
<p>Example 2:</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">let</span> <span onmouseout="hideTip(event, 'fs17', 23)" onmouseover="showTip(event, 'fs17', 23)" class="i">model</span> <span class="o">=</span> <span onmouseout="hideTip(event, 'fs14', 24)" onmouseover="showTip(event, 'fs14', 24)" class="p">Some</span> <span class="s">&quot;Dave&quot;</span>
<span class="c">// or</span>
<span class="k">let</span> <span onmouseout="hideTip(event, 'fs17', 25)" onmouseover="showTip(event, 'fs17', 25)" class="i">model</span> <span class="o">:</span> <span onmouseout="hideTip(event, 'fs4', 26)" onmouseover="showTip(event, 'fs4', 26)" class="t">string</span> <span onmouseout="hideTip(event, 'fs12', 27)" onmouseover="showTip(event, 'fs12', 27)" class="t">option</span> <span class="o">=</span> <span onmouseout="hideTip(event, 'fs15', 28)" onmouseover="showTip(event, 'fs15', 28)" class="p">None</span>

<span class="k">let</span> <span onmouseout="hideTip(event, 'fs16', 29)" onmouseover="showTip(event, 'fs16', 29)" class="i">home</span> <span class="o">=</span> <span class="i">page</span> <span class="s">&quot;Index.html&quot;</span> <span onmouseout="hideTip(event, 'fs17', 30)" onmouseover="showTip(event, 'fs17', 30)" class="i">model</span>
</div></pre>

<br />
<table class="pre"><tr><td class="snippet"><pre class="fssnip highlighted"><div lang="csharp">&lt;div&gt;
  {<span class="o">%</span> <span class="k">if</span> model <span class="o">%</span>}
      Hello {{model.Value}}
  {<span class="o">%</span> <span class="k">else</span> <span class="o">%</span>}
      Dave <span class="k">is</span> not here
  {<span class="o">%</span> endif <span class="o">%</span>}
<span class="o">&lt;</span>/div&gt;
</div></pre>
</td></tr></table>
<h2>References</h2>
<ul>
<li><a href="https://github.com/dotliquid/dotliquid/wiki/DotLiquid-for-Designers">DotLiquid for Designers</a></li>
<li><a href="https://github.com/dotliquid/dotliquid/wiki/DotLiquid-for-Developers">DotLiquid for Developers</a></li>
</ul>


<div class="tip" id="fs1">namespace Suave</div>
<div class="tip" id="fs2">Multiple items<br />module Model<br /><br />from Suave<br /><br />--------------------<br />type Model =<br />&#160;&#160;{title: string;}<br /><br />Full name: temp.Model</div>
<div class="tip" id="fs3">Model.title: string</div>
<div class="tip" id="fs4">Multiple items<br />val string : value:&#39;T -&gt; string<br /><br />Full name: Microsoft.FSharp.Core.Operators.string<br /><br />--------------------<br />type string = System.String<br /><br />Full name: Microsoft.FSharp.Core.string</div>
<div class="tip" id="fs5">val o : Model<br /><br />Full name: temp.o</div>
<div class="tip" id="fs6">val app : WebPart&lt;HttpContext&gt;<br /><br />Full name: temp.app</div>
<div class="tip" id="fs7">val choose : options:WebPart&lt;&#39;a&gt; list -&gt; WebPart&lt;&#39;a&gt;<br /><br />Full name: Suave.WebPart.choose</div>
<div class="tip" id="fs8">union case HttpMethod.GET: HttpMethod</div>
<div class="tip" id="fs9">val path : pathAfterDomain:string -&gt; WebPart<br /><br />Full name: Suave.Filters.path</div>
<div class="tip" id="fs10">type UserModel =<br />&#160;&#160;{UserName: string option;}<br /><br />Full name: temp.UserModel</div>
<div class="tip" id="fs11">UserModel.UserName: string option</div>
<div class="tip" id="fs12">type &#39;T option = Option&lt;&#39;T&gt;<br /><br />Full name: Microsoft.FSharp.Core.option&lt;_&gt;</div>
<div class="tip" id="fs13">val model : UserModel<br /><br />Full name: temp.model</div>
<div class="tip" id="fs14">union case Option.Some: Value: &#39;T -&gt; Option&lt;&#39;T&gt;</div>
<div class="tip" id="fs15">union case Option.None: Option&lt;&#39;T&gt;</div>
<div class="tip" id="fs16">val home : obj<br /><br />Full name: temp.home</div>
<div class="tip" id="fs17">val model : string option<br /><br />Full name: temp.model</div>
