<h1>Getting Hold of Suave's Logs</h1>
<p>Current documentation for configuring Suave is either
<a href="https://github.com/fable-compiler/fable-suave-scaffold/blob/master/src/Server/Server.fs#L24-L28">in this sample</a>
or <a href="https://github.com/logary/logary#using-logary-in-a-library">in the Logary readme</a>.</p>
<p>The below details how to configure Suave v1.x with Logary v3.x:</p>
<p>When you are using suave you will probably want to funnel all logs from the
output to your own log sink. We provide the interface <code>Logger</code> to do that; just
set the propery <code>logger</code> in the configuration to an instance of your thread-safe
logger. An example:</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">type</span> <span onmouseout="hideTip(event, 'fs1', 1)" onmouseover="showTip(event, 'fs1', 1)" class="t">MyHackLogger</span>(<span onmouseout="hideTip(event, 'fs2', 2)" onmouseover="showTip(event, 'fs2', 2)" class="i">minLevel</span>) <span class="o">=</span>
  <span class="k">interface</span> <span onmouseout="hideTip(event, 'fs3', 3)" onmouseover="showTip(event, 'fs3', 3)" class="t">Logger</span> <span class="k">with</span>
    <span class="k">member</span> <span onmouseout="hideTip(event, 'fs4', 4)" onmouseover="showTip(event, 'fs4', 4)" class="i">x</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs5', 5)" onmouseover="showTip(event, 'fs5', 5)" class="f">Log</span> <span onmouseout="hideTip(event, 'fs6', 6)" onmouseover="showTip(event, 'fs6', 6)" class="i">level</span> <span onmouseout="hideTip(event, 'fs7', 7)" onmouseover="showTip(event, 'fs7', 7)" class="i">fLine</span> <span class="o">=</span>
      <span class="k">if</span> <span onmouseout="hideTip(event, 'fs6', 8)" onmouseover="showTip(event, 'fs6', 8)" class="i">level</span> <span class="o">&gt;</span><span class="o">=</span> <span onmouseout="hideTip(event, 'fs2', 9)" onmouseover="showTip(event, 'fs2', 9)" class="i">minLevel</span> <span class="k">then</span>
        <span class="c">// don&#39;t do this for real ;)</span>
        <span onmouseout="hideTip(event, 'fs8', 10)" onmouseover="showTip(event, 'fs8', 10)" class="i">System</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs9', 11)" onmouseover="showTip(event, 'fs9', 11)" class="i">Windows</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs10', 12)" onmouseover="showTip(event, 'fs10', 12)" class="i">Forms</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs11', 13)" onmouseover="showTip(event, 'fs11', 13)" class="t">MessageBox</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs12', 14)" onmouseover="showTip(event, 'fs12', 14)" class="f">Show</span>((<span onmouseout="hideTip(event, 'fs7', 15)" onmouseover="showTip(event, 'fs7', 15)" class="i">fLine</span> ())<span class="o">.</span><span class="i">message</span>)
</div></pre>

<p>You can use Logary for integrated logging:</p>
<table class="pre"><tr><td class="snippet"><pre class="fssnip"><div lang="bash">Install-Package Logary.Adapters.Suave
</div></pre>
</td></tr></table>
<p>Use the <code>SuaveAdapter</code> type to set the Logger in Suave's configuration:</p>
<pre class="fssnip highlighted"><div lang="fsharp"><span class="k">open</span> <span onmouseout="hideTip(event, 'fs13', 16)" onmouseover="showTip(event, 'fs13', 16)" class="i">Suave</span><span class="o">.</span><span onmouseout="hideTip(event, 'fs14', 17)" onmouseover="showTip(event, 'fs14', 17)" class="i">Logging</span>

<span class="k">use</span> <span onmouseout="hideTip(event, 'fs15', 18)" onmouseover="showTip(event, 'fs15', 18)" class="i">logary</span> <span class="o">=</span>
  <span class="i">withLogary&#39;</span> <span class="s">&quot;logibit.web&quot;</span> (
    <span class="i">withTargets</span> [
      <span class="i">Console</span><span class="o">.</span><span class="i">create</span> <span class="i">Console</span><span class="o">.</span><span class="i">empty</span> <span class="s">&quot;console&quot;</span>
      <span class="i">Debugger</span><span class="o">.</span><span class="i">create</span> <span class="i">Debugger</span><span class="o">.</span><span class="i">empty</span> <span class="s">&quot;debugger&quot;</span>
    ] <span class="o">&gt;</span><span class="o">&gt;</span>
    <span class="i">withMetrics</span> (<span class="i">Duration</span><span class="o">.</span><span class="i">FromMilliseconds</span> <span class="n">5000L</span>) [
      <span class="i">WinPerfCounters</span><span class="o">.</span><span class="i">create</span> (<span class="i">WinPerfCounters</span><span class="o">.</span><span class="i">Common</span><span class="o">.</span><span class="i">cpuTimeConf</span>) <span class="s">&quot;wperf&quot;</span>
(<span class="i">Duration</span><span class="o">.</span><span class="i">FromMilliseconds</span> <span class="n">300L</span>)
      ] <span class="o">&gt;</span><span class="o">&gt;</span>
      <span class="i">withRules</span> [
        <span class="i">Rule</span><span class="o">.</span><span class="i">createForTarget</span> <span class="s">&quot;console&quot;</span>
        <span class="i">Rule</span><span class="o">.</span><span class="i">createForTarget</span> <span class="s">&quot;debugger&quot;</span>
      ]
    )

<span class="k">let</span> <span onmouseout="hideTip(event, 'fs16', 19)" onmouseover="showTip(event, 'fs16', 19)" class="i">webConfig</span> <span class="o">=</span>
  { <span onmouseout="hideTip(event, 'fs17', 20)" onmouseover="showTip(event, 'fs17', 20)" class="i">defaultConfig</span> <span class="k">with</span>
      <span class="i">logger</span>   <span class="o">=</span> <span class="i">SuaveAdapter</span>(<span onmouseout="hideTip(event, 'fs15', 21)" onmouseover="showTip(event, 'fs15', 21)" class="i">logary</span><span class="o">.</span><span class="i">GetLogger</span> <span class="s">&quot;suave&quot;</span>)
  }
</div></pre>



<div class="tip" id="fs1">Multiple items<br />type MyHackLogger =<br />&#160;&#160;interface Logger<br />&#160;&#160;new : minLevel:IComparable -&gt; MyHackLogger<br />&#160;&#160;override Log : level:IComparable -&gt; fLine:&#39;a -&gt; unit<br /><br />Full name: temp.MyHackLogger<br /><br />--------------------<br />new : minLevel:System.IComparable -&gt; MyHackLogger</div>
<div class="tip" id="fs2">val minLevel : System.IComparable</div>
<div class="tip" id="fs3">type Logger =<br />&#160;&#160;interface<br />&#160;&#160;&#160;&#160;abstract member name : string []<br />&#160;&#160;&#160;&#160;abstract member log : LogLevel -&gt; (LogLevel -&gt; Message) -&gt; Async&lt;unit&gt;<br />&#160;&#160;&#160;&#160;abstract member logWithAck : LogLevel -&gt; (LogLevel -&gt; Message) -&gt; Async&lt;unit&gt;<br />&#160;&#160;end<br /><br />Full name: Suave.Logging.Logger</div>
<div class="tip" id="fs4">val x : MyHackLogger</div>
<div class="tip" id="fs5">Multiple items<br />override MyHackLogger.Log : level:System.IComparable -&gt; fLine:&#39;a -&gt; unit<br /><br />Full name: temp.MyHackLogger.Log<br /><br />--------------------<br />module Log<br /><br />from Suave.Logging</div>
<div class="tip" id="fs6">val level : System.IComparable</div>
<div class="tip" id="fs7">val fLine : &#39;a</div>
<div class="tip" id="fs8">namespace System</div>
<div class="tip" id="fs9">namespace System.Windows</div>
<div class="tip" id="fs10">namespace System.Windows.Forms</div>
<div class="tip" id="fs11">type MessageBox =<br />&#160;&#160;static member Show : text:string -&gt; DialogResult + 20 overloads<br /><br />Full name: System.Windows.Forms.MessageBox</div>
<div class="tip" id="fs12">System.Windows.Forms.MessageBox.Show(text: string) : System.Windows.Forms.DialogResult<br />&#160;&#160;&#160;<em>(+0 other overloads)</em><br />System.Windows.Forms.MessageBox.Show(text: string, caption: string) : System.Windows.Forms.DialogResult<br />&#160;&#160;&#160;<em>(+0 other overloads)</em><br />System.Windows.Forms.MessageBox.Show(owner: System.Windows.Forms.IWin32Window, text: string) : System.Windows.Forms.DialogResult<br />&#160;&#160;&#160;<em>(+0 other overloads)</em><br />System.Windows.Forms.MessageBox.Show(owner: System.Windows.Forms.IWin32Window, text: string, caption: string) : System.Windows.Forms.DialogResult<br />&#160;&#160;&#160;<em>(+0 other overloads)</em><br />System.Windows.Forms.MessageBox.Show(text: string, caption: string, buttons: System.Windows.Forms.MessageBoxButtons) : System.Windows.Forms.DialogResult<br />&#160;&#160;&#160;<em>(+0 other overloads)</em><br />System.Windows.Forms.MessageBox.Show(text: string, caption: string, buttons: System.Windows.Forms.MessageBoxButtons, icon: System.Windows.Forms.MessageBoxIcon) : System.Windows.Forms.DialogResult<br />&#160;&#160;&#160;<em>(+0 other overloads)</em><br />System.Windows.Forms.MessageBox.Show(owner: System.Windows.Forms.IWin32Window, text: string, caption: string, buttons: System.Windows.Forms.MessageBoxButtons) : System.Windows.Forms.DialogResult<br />&#160;&#160;&#160;<em>(+0 other overloads)</em><br />System.Windows.Forms.MessageBox.Show(text: string, caption: string, buttons: System.Windows.Forms.MessageBoxButtons, icon: System.Windows.Forms.MessageBoxIcon, defaultButton: System.Windows.Forms.MessageBoxDefaultButton) : System.Windows.Forms.DialogResult<br />&#160;&#160;&#160;<em>(+0 other overloads)</em><br />System.Windows.Forms.MessageBox.Show(owner: System.Windows.Forms.IWin32Window, text: string, caption: string, buttons: System.Windows.Forms.MessageBoxButtons, icon: System.Windows.Forms.MessageBoxIcon) : System.Windows.Forms.DialogResult<br />&#160;&#160;&#160;<em>(+0 other overloads)</em><br />System.Windows.Forms.MessageBox.Show(text: string, caption: string, buttons: System.Windows.Forms.MessageBoxButtons, icon: System.Windows.Forms.MessageBoxIcon, defaultButton: System.Windows.Forms.MessageBoxDefaultButton, options: System.Windows.Forms.MessageBoxOptions) : System.Windows.Forms.DialogResult<br />&#160;&#160;&#160;<em>(+0 other overloads)</em></div>
<div class="tip" id="fs13">namespace Suave</div>
<div class="tip" id="fs14">namespace Suave.Logging</div>
<div class="tip" id="fs15">val logary : obj<br /><br />Full name: temp.logary</div>
<div class="tip" id="fs16">val webConfig : SuaveConfig<br /><br />Full name: temp.webConfig</div>
<div class="tip" id="fs17">val defaultConfig : SuaveConfig<br /><br />Full name: Suave.Web.defaultConfig</div>
