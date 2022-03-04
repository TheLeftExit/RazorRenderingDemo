using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.RenderTree;

namespace RazorRenderingDemo;

#pragma warning disable BL0006 // Do not use RenderTree types
public static class RazorComponentRenderer {
    public static void Render(IRenderableComponent component, Action<string> write) {
        using (var builder = new RenderTreeBuilder()) {
            component.Build(builder);
            var frames = builder.GetFrames();

            // Very loosely based on:
            // https://source.dot.net/#Microsoft.AspNetCore.Mvc.ViewFeatures/RazorComponents/HtmlRenderer.cs
            // (could not be reused due to DI dependencies)

            bool isInElement = false;
            Stack<(string Name, int EndPosition)> elementStack = new();

            foreach (var frame in frames.Array.Take(frames.Count)) {
                if (isInElement && frame.FrameType != RenderTreeFrameType.Attribute) {
                    write(">");
                    isInElement = false;
                }

                switch (frame.FrameType) {
                    case RenderTreeFrameType.Text:
                    case RenderTreeFrameType.Markup:
                        write(frame.TextContent);
                        break;
                    case RenderTreeFrameType.Element:
                        write($"<{frame.TextContent}");
                        isInElement = true;
                        elementStack.Push((frame.ElementName, frame.Sequence + frame.ElementSubtreeLength - 1));
                        break;
                    case RenderTreeFrameType.Attribute:
                        write($" {frame.AttributeName}=\"{frame.AttributeValue}\"");
                        break;
                }

                while (elementStack.TryPeek(out var result) && result.EndPosition == frame.Sequence) {
                    Console.Write($"</{elementStack.Pop().Name}>");
                }
            }

        }
    }
}