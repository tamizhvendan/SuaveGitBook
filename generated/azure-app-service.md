<h1>Deploying Suave to Azure App Service</h1>
<p>Suave Web Sites in Azure App Service can be deployed either as an F# script with a suitable host e.g. FAKE, or as a standalone executable. This tutorial will focus on: -</p>
<ul>
<li>Hosting a Suave console application in Azure App Service</li>
<li>Deploying and building your Suave application from source control directly in the Azure App Service</li>
<li>Instructing the Azure App Service IIS host to redirect all traffic to Suave</li>
</ul>
<h3>1. Create a <code>web.config</code> file.</h3>
<p>This file instructs IIS to act as a passthrough and to redirect all traffic through to Suave.</p>
<table class="pre"><tr><td class="snippet"><pre class="fssnip highlighted"><div lang="xml"><span class="prep">&lt;?</span>xml version=<span class="s">"1.0"</span> encoding=<span class="s">"UTF-8"</span><span class="prep">?&gt;</span>
<span class="k">&lt;</span><span class="i">configuration</span><span class="k">&gt;</span>
  <span class="k">&lt;</span><span class="i">system.webServer</span><span class="k">&gt;</span>
    <span class="k">&lt;</span><span class="i">handlers</span><span class="k">&gt;</span>
      <span class="k">&lt;</span><span class="i">remove</span> <span class="o">name</span><span class="k">="httpplatformhandler"</span> <span class="k">/&gt;</span>
      <span class="k">&lt;</span><span class="i">add</span> <span class="o">name</span><span class="k">="httpplatformhandler"</span> <span class="o">path</span><span class="k">="*"</span> <span class="o">verb</span><span class="k">="*"</span> <span class="o">modules</span><span class="k">="httpPlatformHandler"</span> 
      <span class="o">resourceType</span><span class="k">="Unspecified"</span><span class="k">/&gt;</span>
    <span class="k">&lt;/</span><span class="i">handlers</span><span class="k">&gt;</span>
    <span class="k">&lt;</span><span class="i">httpPlatform</span> <span class="o">stdoutLogEnabled</span><span class="k">="true"</span> <span class="o">stdoutLogFile</span><span class="k">=".\suave.log"</span> <span class="o">startupTimeLimit</span><span class="k">="20"</span> 
    <span class="o">processPath</span><span class="k">="%HOME%\site\wwwroot\SuaveHost.exe"</span> <span class="o">arguments</span><span class="k">="%HTTP_PLATFORM_PORT%"</span><span class="k">/&gt;</span>
  <span class="k">&lt;/</span><span class="i">system.webServer</span><span class="k">&gt;</span>
<span class="k">&lt;/</span><span class="i">configuration</span><span class="k">&gt;</span>
</div></pre>
</td></tr></table>
<ul>
<li>Notice the use of the <code>processPath</code> attribute which tells IIS which executable to host. Change the content from SuaveHost.exe to the name of your application.</li>
<li>Also note the use of <code>%HTTP_PLATFORM_PORT%</code> as an argument to Suave. This tells Suave which port it should listen on for inbound HTTP traffic.</li>
<li>This file does <em>not</em> replace your <code>app.config</code> file, which should remain.</li>
</ul>
<h3>2. Create a <code>.deployment</code> file.</h3>
<p>At this point, you can elect to manually FTP your Suave application into the Azure App Service into <code>site\wwwroot</code> - it should just work. However, if you want an automated deployment process from source control, continue with the following steps.</p>
<p>This file tells Azure App Service what to do after downloading your application code i.e. your build script e.g.</p>
<table class="pre"><tr><td class="snippet"><pre class="fssnip"><div lang="bash">[config]
command = build.cmd
</div></pre>
</td></tr></table>
<p>In this case, it will run <code>build.cmd</code>. Of course, this can do anything you want. The output should be that your application is copied into the <code>site\wwwroot</code> folder.</p>
<ul>
<li>Run Paket</li>
<li>Download Nuget dependencies</li>
<li>Kick off msbuild (installed by default)</li>
</ul>
<p>Recommended practice is to use something like FAKE to orchestrate your build. FAKE also contains helpers for the Azure App Service "Kudu" feature, which performs diff copies between the "current" version of the application and the latest version.</p>
<h3>3. Bind Azure App Service to repository.</h3>
<p>Create a Web App in the <a href="https://azure.microsoft.com/en-us/services/app-service/">Azure App Service</a> from the Azure portal. Then, <a href="https://azure.microsoft.com/en-us/documentation/articles/web-sites-publish-source-control/">connect it to your source control repository of choice</a> e.g. GitHub, BitBucket etc.</p>
<p>Azure will immediately download the source code and kick off the build script you specified in step 2. Every commit to the branch in future will kick off the same process.</p>
<p>Once hosted, you can use the Settings and Tools in the service to e.g. check deployments, view logs, scale out etc. etc.</p>


