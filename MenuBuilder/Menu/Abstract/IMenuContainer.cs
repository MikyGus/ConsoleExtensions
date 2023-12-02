using ConsoleExtensions.Menu.Fixed;
using ConsoleExtensions.Models;

namespace ConsoleExtensions.Menu.Abstract;
internal interface IMenuContainer : IMenuContainerChild
{
    IEnumerable<IMenuContainerChild> Children { get; }
    ContainerChildOrientation OrientationOfChildren { get; set; }
    Vector2 OffsetBetweenChildren { get; }
    int SelectedIndex { get; set; }
    void SelectByValue<T>(T value);
    void AddChild(IMenuContainerChild child);
}
