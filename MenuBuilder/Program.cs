using ConsoleExtensions.Menu;
using ConsoleExtensions.Menu.Fixed;
using ConsoleExtensions.Menu.Models;
using ConsoleExtensions.Models;

var menu = new MenuContainerBuilder()
    .Title("Settings")
    .Orientation(ContainerChildOrientation.Vertical)
    .AddChild(new MenuContainerBuilder()
        .Orientation(ContainerChildOrientation.Horizontal)
        .Title("Players")
        .AddChild(new MenuContainerBuilder()
            .Orientation(ContainerChildOrientation.Vertical)
            .Title("Number of players")
            .AddChild(new MenuContainerItem<int>(5))
            .AddChild(new MenuContainerItem<int>(7))
            .AddChild(new MenuContainerItem<int>(8))
            .SelectByValue(7)
            .Build())
            .AddChild(new MenuContainerBuilder()
                .Orientation(ContainerChildOrientation.Vertical)
                .Title("Colors")
                .Build())
            .AddChild(new MenuContainerBuilder()
                .Orientation(ContainerChildOrientation.Vertical)
                .Title("Names")
                .Build())
        .Build())
    .AddChild(new MenuContainerBuilder()
        .Orientation(ContainerChildOrientation.Horizontal)
        .Title("GridSize")
        .Build())
    .SelectByIndex(5)
    .Build();

menu.Position = new Vector2(1, 1);
menu.Render();

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();