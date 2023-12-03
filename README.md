# RazorRenderingDemo
Proof of concept Razor component rendering

The [Microsoft.AspNetCore.Components.Web.HtmlRenderer](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.web.htmlrenderer) class provides an API to render a Razor component to a string arbitrarily at runtime. However, it is intended to be used within the context of a fully fledged ASP.NET application, so you can't simply create and use it in a console application.

This example uses reflection and dummy interface implementations to create a console-compatible **HtmlRenderer** instance (see: [RazorComponentRenderer.cs](RazorComponentRenderer.cs)). The example works with .NET 8, and may stop working if private field names are changed in future .NET versions.

[Program.cs](Program.cs) renders a simple component with inlined properties and expressions to console.

