using MenuBuilder.Menu;
using MenuBuilder.Menu.Fixed;
using MenuBuilder.Menu.Models;

var menu = new MenuContainerBuilder()
    .Title("Settings")
    .Orientation(ContainerChildOrientation.Vertical)
    .AddChild(new MenuContainerBuilder()
        .Orientation(ContainerChildOrientation.Horizontal)
        .Title("Players")
        .Build())
    .AddChild(new MenuContainerBuilder()
        .Orientation(ContainerChildOrientation.Horizontal)
        .Title("GridSize")
        .Build())
    .SelectByIndex(1)
    .Build();

menu.Position = new Vector2(1, 1);
menu.Render();

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();