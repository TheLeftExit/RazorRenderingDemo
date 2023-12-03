using RazorRenderingDemo;

var component = new MyComponent() {
    Name = "SampleName",
    Id = 0
};

Console.WriteLine(await component.RenderAsync());
Console.ReadKey();