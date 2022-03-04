# RazorRenderingDemo
Proof of concept Razor component rendering

The [**ComponentBase.BuildRenderTree**](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.componentbase.buildrendertree) method (overriden in the code generated for the component) can be used to create a sequence of tree elements, which can then be relatively easily parsed.

Notes:
 - It may be possible to do this in a more optimal way by somehow reusing the [**HtmlRenderer**](https://source.dot.net/#Microsoft.AspNetCore.Mvc.ViewFeatures/RazorComponents/HtmlRenderer.cs) class.
 - Per Microsoft:
   > *Types in the Microsoft.AspNetCore.Components.RenderTree are not recommended for use outside of the Blazor framework. These types will change in future release.*
