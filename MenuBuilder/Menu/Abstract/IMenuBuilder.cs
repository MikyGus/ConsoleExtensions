using MenuBuilder.Menu.Fixed;

namespace MenuBuilder.Menu.Abstract;
internal interface IMenuBuilder
{
    IMenuBuilder Orientation(ContainerChildOrientation orientation);
    IMenuBuilder Title(string title);
    IMenuBuilder AddChild(IMenuContainerChild item);
    /// <summary>
    /// Selects child of container at specified index. May be set before or after children have been added.
    /// </summary>
    /// <param name="index">Child at this index to be selected</param>
    /// <returns>IMenuBuilder</returns>
    IMenuBuilder SelectByIndex(int index);
    /// <summary>
    /// Selects child of container by the containers value. 
    /// Only selects IMenuChildItems! 
    /// May only be specified AFTER the children have been added.
    /// The Equals() method is used for equality.
    /// </summary>
    /// <typeparam name="T">MenuChildItems type of value</typeparam>
    /// <param name="value">Value of MenuChildItem to select</param>
    /// <exception cref="ArgumentException">Thrown when specified value is not found among the containers children.</exception>
    /// <returns>IMenuBuilder</returns>
    IMenuBuilder SelectByValue<T>(T value);
    IMenuContainer Build();
}
