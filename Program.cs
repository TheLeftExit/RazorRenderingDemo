namespace RazorRenderingDemo;

class Program {
    static void Main() {
        var index = new Index() {
            Name = "SampleName",
            Id = 0
        };

        RazorComponentRenderer.Render(index, Console.Write);
        Console.ReadKey();
    }
}