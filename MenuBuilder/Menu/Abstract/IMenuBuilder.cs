using ConsoleExtensions.Menu.Fixed;

namespace ConsoleExtensions.Menu.Abstract;
internal interface IMenuBuilder
{
    IMenuBuilder Orientation(ContainerChildOrientation orientation);
    IMenuBuilder Title(string title);
    IMenuBuilder AddChild(IMenuContainerChild item);
    IMenuBuilder SelectByIndex(int index);
    IMenuBuilder SelectByValue<T>(T value);
    IMenuContainer Build();
}
