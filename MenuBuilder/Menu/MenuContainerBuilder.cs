using MenuBuilder.Menu.Abstract;
using MenuBuilder.Menu.Fixed;
using MenuBuilder.Menu.Models;

namespace MenuBuilder.Menu;
internal class MenuContainerBuilder : IMenuBuilder
{
    private readonly IMenuContainer _container;

    private int _indexToSelect = 0;

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

    public IMenuContainer Build()
    {
        _container.SelectedIndex = _indexToSelect;
        return _container;
    }

    public IMenuBuilder SelectByIndex(int index)
    {
        _indexToSelect = index;
        return this;
    }
    public IMenuBuilder SelectByValue<T>(T value) => throw new NotImplementedException();
}
