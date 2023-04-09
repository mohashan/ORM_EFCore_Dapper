<h1> What is "Dependency Injection"?</h1>
<h4>and compare Microsoft DI with Autofac</h4>

<p>Suppose you use an external weather forecasting service in your application. 
You must create an instance of this service wherever you need to use it. But it makes your code 
dependent on that service.</p>
<ul>
<h3>Service lifetime cycle</h3>
<li>Singleton</li>
<li>Scoped</li>
<li>Transient</li>
</ul>

<h3>Comparison of key features</h3>
<h4>Add To Project</h4>
<p>Microsoft DI</p>
<p><code>No need. Dotnet built-in</code></p>
<p>Autofac</p>
<p><code>PM> Install-Package Autofac</code><br/>
<code>PM> Install-Package Autofac.Extension.DependencyInjection</code></p>

<h4>Registration</h4>

<h4>Service lifetimes</h4>

<h3>Autofac awesome features</h3>
<li>Instance per matching lifetime scope</li>
<li>Thread Scope</li>
<li>Named and Keyed Services</li>
<li>Dynamic Instantiayion</li>


<h3>Some Other features</h3>
<li>Adding Metadata to a Component Registration</li>
<li>Delayed Instantiation</li>

<h3>Conclusion</h3>
<p>
Funamentally the difference is in the additional features and choosing the best framework 
depends on your project needs but Autofac can offer you some additional features if you need them.
</p>
<p>
For simple application, the Microsoft DI can offer adequate functionality
</p>
