using Microsoft.AspNetCore.Components.Rendering;

public interface IRenderableComponent {
    void Build(RenderTreeBuilder builder);
}