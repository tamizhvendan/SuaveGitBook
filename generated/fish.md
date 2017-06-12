<h1>Programming with fish (custom operator reference)</h1>
<p>Functional programming tends to involve custom operators. An excessive number of custom operators makes for cryptic, illegible code, but a few well chosen ones allow logic to be more succint and readable. We have already seen <code>&gt;=&gt;</code>, and happily suave does not use either <code>&gt;&lt;&lt;*&gt; or &lt;*)))&gt;{</code></p>
<p>The other custom operators it declares are:</p>
<table>
<thead>
<tr class="header">
<th><p>Operator</p></th>
<th><p>Description</p></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td><p><code>&gt;=&gt;</code></p></td>
<td><p>Left-to-right Kleisli composition of monads, see Http.fsi</p></td>
</tr>
<tr class="even">
<td><&#124;></td>
<td><p>Left-to-right Kleisli composition of web parts, see Http.fsi</p></td>
</tr>
<tr class="odd">
<td><p>?</p></td>
<td><p>Try find a value by key in a dictionary</p></td>
</tr>
<tr class="even">
<td><p>%%</p></td>
<td><p>Search a list of key-value pairs and return the value (or None if not found)</p></td>
</tr>
<tr class="odd">
<td><p>^^</p></td>
<td><p>Search a list of key-value option pairs and return the value (or None if not found)</p></td>
</tr>
<tr class="even">
<td><p>?&lt;-</p></td>
<td><p>Assign a value to the key in the dictionary</p></td>
</tr>
</tbody>
</table>



