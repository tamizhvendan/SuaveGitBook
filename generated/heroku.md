<h1>Deploying Suave to Heroku</h1>
<p>Suave web sites can be as simple as a single F# script which starts a web server, or a full project.</p>
<p>Your application needs to be either a single script <code>app.fsx</code> (plus a Heroku <code>Procfile</code> and <code>dummy.sln</code> file) OR
a directory with a <code>.sln</code> solution (plus a Heroku <code>Procfile</code>)</p>
<p>Optionally, you can have a <code>paket.dependencies</code> OR <code>packages.config</code> files</p>
<p>Either way, your application must start a web server that binds to 0.0.0.0:$PORT.</p>
<p>Your <code>Procfile</code> must specify how the application starts.</p>
<p>If you don't have an app.fsx already that implements your website, then clone an example, putting it in a new directory (replace myproj by a unique project name)</p>
<p>You can one-click-deploy the Suave sample to Heroku by clicking the button below.</p>
<p><a href="https://heroku.com/deploy?template=https://github.com/SuaveIO/heroku-getting-started"><img src="https://www.herokucdn.com/deploy/button.png" alt="Deploy" /></a></p>
<p>Or deploy the sample from the CLI.</p>
<ol>
<li><a href="https://toolbelt.heroku.com/">Install the Heroku Toolbelt</a> and login to Heroku using the command-line tools:</li>
</ol>
<pre class="fssnip highlighted"><div lang="fsharp">    <span class="i">heroku</span> <span class="i">login</span>
</div></pre>

<ol>
<li>Clone the sample:</li>
</ol>
<pre class="fssnip highlighted"><div lang="fsharp">    <span class="i">git</span> <span class="i">clone</span> <span class="i">https</span><span class="o">:</span><span class="c">//github.com/SuaveIO/heroku-getting-started.git myproj</span>
    <span class="i">cd</span> <span class="i">myproj</span>
</div></pre>

<ol>
<li>Create a new heroku web app and register "heroku" as a remote you can push to:</li>
</ol>
<pre class="fssnip highlighted"><div lang="fsharp">    <span class="i">heroku</span> <span class="i">create</span> <span class="i">myproj</span> <span class="o">--</span><span class="i">buildpack</span> <span class="i">https</span><span class="o">:</span><span class="c">//github.com/SuaveIO/mono-script-buildpack.git </span>
</div></pre>

<ol>
<li>Push!</li>
</ol>
<pre class="fssnip highlighted"><div lang="fsharp">    <span class="i">git</span> <span class="i">push</span> <span class="i">heroku</span> <span class="i">master</span>
</div></pre>

<p>When pushing, use an empty user name. You may need to use <code>git auth:token</code> to get a app token to use as a password here.</p>
<p>You can change the buildpack being used at a later date (e.g. to update to a later version of Mono) using</p>
<table class="pre"><tr><td class="snippet"><pre class="fssnip"><div lang="bash">heroku buildpack:set https://github.com/your-build-pack-repo
</div></pre>
</td></tr></table>
<p>If using github or bitbucket, find your app on Heroku and enable automatic deploy so you don't need to push explciitly.</p>
<p>You can look at logs from your web server script using <code>heroku logs</code>.</p>


