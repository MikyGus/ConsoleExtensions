using ConsoleExtensions.Menu.Abstract;
using ConsoleExtensions.Menu.Fixed;
using ConsoleExtensions.Menu.Models;

namespace ConsoleExtensions.Menu;
internal class MenuContainerBuilder : IMenuBuilder
{
    private readonly IMenuContainer _container;

    public MenuContainerBuilder()
    {
        _container = new MenuContainer();
    }

    public IMenuBuilder AddChild(IMenuContainerChild item)
    {
        _container.AddChild(item);
        return this;
    }
    public IMenuBuilder Orientation(ContainerChildOrientation orientation)
    {
        _container.OrientationOfChildren = orientation;
        return this;
    }
    public IMenuBuilder Title(string title)
    {
        _container.Title = title;
        return this;
    }

    public IMenuContainer Build() => _container;
    /// <summary>
    /// Selects child of container at specified index. 
    /// May only be specified AFTER the children have been added.
    /// The index-value will be altered to upper or lower bound if specified index is out of bounds.
    /// </summary>
    /// <param name="index">Child at this index to be selected</param>
    /// <returns>IMenuBuilder</returns>
    public IMenuBuilder SelectByIndex(int index)
    {
        _container.SelectedIndex = index;
        return this;
    }
    /// <summary>
    /// Selects child of container by the containers value. 
    /// Only selects IMenuChildItems! 
    /// May only be specified AFTER the children have been added.
    /// The Equals() method is used for equality.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when specified value is not found among the containers children.</exception>
    /// <typeparam name="T">MenuChildItems type of value</typeparam>
    /// <param name="value">Value of MenuChildItem to select</param>
    /// <returns>IMenuBuilder</returns>
    public IMenuBuilder SelectByValue<T>(T value)
    {
        _container.SelectByValue(value);
        return this;
    }
}
