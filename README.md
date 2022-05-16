# RazorRenderingDemo
Proof of concept Razor component rendering

The [**ComponentBase.BuildRenderTree**](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.componentbase.buildrendertree) method (overriden in the code generated for the component) can be used to create a sequence of tree elements, which can then be relatively easily parsed.

[**Program.cs**](Program.cs) renders a simple component with inlined properties and expressions to console.

Notes:
 - ~~It may be possible to do this in a more optimal way by somehow reusing the [**HtmlRenderer**](https://source.dot.net/#Microsoft.AspNetCore.Mvc.ViewFeatures/RazorComponents/HtmlRenderer.cs) class.~~  
The [HtmlRenderer.RenderComponentAsync](https://source.dot.net/#Microsoft.AspNetCore.Mvc.ViewFeatures/RazorComponents/HtmlRenderer.cs,97cbbf07350ec9ed) method throws unless it is called within the context of rendering a page while processing an HTTP request (or something), so reusing it is likely impossible and definitely less practical than rewriting its functionality from scratch.
 - Per Microsoft:
   > *Types in the Microsoft.AspNetCore.Components.RenderTree are not recommended for use outside of the Blazor framework. These types will change in future release.*
