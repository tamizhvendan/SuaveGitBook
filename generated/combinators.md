<h1>More HTTP combinators</h1>
<p>The documentation for the HTTP combinators is written in
<a href="https://github.com/SuaveIO/suave/blob/master/src/Suave/Combinators.fsi">Http.fsi</a> - so
it's recommended you explore the modules using the code-completion of your IDE,
or by looking at the linked file.</p>
<p>All-in-all, the Http combinators consists of these sub-modules:</p>
<dl>
<dt>Compression</dt>
<dd>Functions for compressing responses.</dd>
<dt>Response</dt>
<dd>response and response_f functions.</dd>
<dt>Writers</dt>
<dd>ways to modify the response.</dd>
<dt>Intermediate - </dt>
<dd>100 and 101 response codes.</dd>
<dt>Successful</dt>
<dd>2xx response codes.</dd>
<dt>Redirection</dt>
<dd>3xx response codes.</dd>
<dt>RequestErrors - </dt>
<dd>4xx response codes.</dd>
<dt>ServerErrors</dt>
<dd>5xx response codes.</dd>
<dt>Filters</dt>
<dd>use to filter down the request to something you</dd>
<dt>Files</dt>
<dd>send files to the client</dd>
<dt>Authentication</dt>
<dd>Methods for authenticating http requests</dd>
</dl>
<p>The numeric/discriminated-union HTTP codes can be found in <code>Suave.Http.Codes</code>.</p>


